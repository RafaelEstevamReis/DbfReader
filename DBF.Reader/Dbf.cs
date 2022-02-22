/***********************************************
* 
*  Author RafaelEstevam
*  Date: MAY-2019
*  Description: Simple DBF Reader
* 
/***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;

namespace DBF.Reader
{
    public class Table
    {
        public static Encoding DefaultEncoding { get; set; } = Encoding.ASCII;
        public ProgressChangedEventHandler LoadProgressChanged;

        public Encoding Encoding { get; private set; }

        string tableName;
        private Header header;

        private Table()
        {
            header = Header.CreateHeader(Versions.FoxBaseDBase3NoMemo);
            Fields = new List<Field>();
            Records = new List<Record>();
        }

        public uint HeaderRowCount => header.RowCount;
        public int RowCount => Records.Count;
        public List<Field> Fields { get; }
        public List<Record> Records { get; }

        void reportProgress(int current, int rowCount)
        {
            int percent = 0;
            if (RowCount > 0) percent = (int)((current * 100f) / rowCount);

            if (percent == lastProgressReport) return;
            reportProgress(percent);
        }
        int lastProgressReport = 0;
        void reportProgress(int percent)
        {
            if (LoadProgressChanged == null) return;
            lastProgressReport = percent;
            LoadProgressChanged(this, new ProgressChangedEventArgs(percent, null));
        }
        void read(string path)
        {
            reportProgress(0);
            tableName = new FileInfo(path).Name.Split('.')[0];
            // Open stream for reading.
            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Process reader
                    // Get Memo data
                    // Get Fields
                    // reposition the cursor
                    // read data

                    readHeader(reader);
                    byte[] memoData = readMemos(path);

                    reportProgress(1); // 1%
                    readFields(reader);

                    // 2+%
                    reportProgress(2);
                    stream.Seek(header.HeaderLen, SeekOrigin.Begin);
                    readRecords(reader, memoData);
                }
            }
            reportProgress(100);
        }

        private byte[] readMemos(string path)
        {
            string memoPath = Path.ChangeExtension(path, "fpt");
            if (!File.Exists(memoPath))
            {
                memoPath = Path.ChangeExtension(path, "dbt");
                if (!File.Exists(memoPath))
                {
                    return null;
                }
            }

            using (FileStream str = File.Open(memoPath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader memoReader = new BinaryReader(str))
                {
                    byte[] memoData = new byte[str.Length];
                    memoData = memoReader.ReadBytes((int)str.Length);
                    return memoData;
                }
            }
        }

        private void readHeader(BinaryReader reader)
        {
            byte bVersion = reader.ReadByte();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            var version = (Versions)bVersion;
            header = Header.CreateHeader(version);
            header.Read(reader);

            header.Encoding = Encoding;
        }
        private void readFields(BinaryReader reader)
        {
            Fields.Clear();

            while (reader.PeekChar() != 0x0d)
            {
                Fields.Add(new Field(reader));
            }
            // Consume 'end field' byte
            reader.ReadByte();
        }
        private void readRecords(BinaryReader reader, byte[] memoData)
        {
            Records.Clear();

            while (reader.PeekChar() != 0x1a && reader.PeekChar() != -1)
            {
                Records.Add(new Record(reader, header, Fields, memoData));
                reportProgress(Records.Count, (int)HeaderRowCount);
            }
        }

        public DataTable ToDataTable()
        {
            var dt = new DataTable(tableName);
            foreach (var v in Fields)
            {
                var t = v.GetNativeType();

                if (v.Type == FieldType.Logical) t = typeof(bool);
                var cln = dt.Columns.Add(v.Name, t);
                cln.AllowDBNull = true;
            }

            foreach (var r in Records)
            {
                if (r.Deleted) continue;
                dt.Rows.Add(r.Data.ToArray());
            }

            return dt;
        }
        public IEnumerable<T> Get<T>()
        {
            var type = typeof(T);

            foreach (var r in Records)
            {
                T t = Activator.CreateInstance<T>();

                foreach (var prop in type.GetProperties())
                {
                    int fieldIndex = Fields.FindIndex(o => o.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase));
                    if (fieldIndex < 0) continue;

                    var data = r.Data[fieldIndex];
                    if (data == null) continue;                    
                    var fieldType = Fields[fieldIndex].GetNativeType();

                    prop.SetValue(t, Convert.ChangeType(data, fieldType));
                }

                yield return t;
            }
        }

        public string ExportModelClassTemplate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public record {tableName}");
            sb.AppendLine("{");
            foreach (var f in Fields)
            {
                var native = f.GetNativeType();
                string typeName = native.Name;
                if (typeName == "Nullable`1") typeName = $"{native.GenericTypeArguments[0].Name}?";

                typeName = typeName.Replace("String", "string")
                                   .Replace("Int32", "int")
                                   .Replace("Boolean", "bool")
                                   .Replace("Single", "float")
                                   .Replace("Double", "double")
                                   .Replace("Decimal", "decimal")
                                   ;

                var field = $"\tpublic {typeName} {f.Name} {{get ; set; }}";
                sb.AppendLine(field);
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static Table Open(string Path, IProgress<int> Progress = null, Encoding encoding = null)
        {
            if (encoding == null) encoding = DefaultEncoding;

            Table t = new Table();
            t.Encoding = encoding;
            if (Progress != null)
            {
                t.LoadProgressChanged += (s, e) => Progress.Report(e.ProgressPercentage);
            }
            t.read(Path);

            return t;
        }
        public static DataTable Load(string Path, IProgress<int> Progress = null)
        {
            Table t = new Table();
            if (Progress != null)
            {
                t.LoadProgressChanged += (s, e) => Progress.Report(e.ProgressPercentage);
            }
            t.read(Path);
            return t.ToDataTable();
        }
    }
}
