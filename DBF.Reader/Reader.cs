/***********************************************
* 
*  Author RafaelEstevam
*  Date: MAY-2019
*  Description: Simple DBF Reader
* 
/***********************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Simple.DBF
{
    public class Reader : IEnumerable<DataRow>
    {
        const byte EOF = 0x1A;
        public static Encoding DefaultEncoding { get; set; } = Encoding.ASCII;
        public ProgressChangedEventHandler LoadProgressChanged;

        public Encoding Encoding { get; private set; }
        public string TableName { get; private set; }
        public string FilePath { get; private set; }

        private Header header;

        private Reader()
        {
            header = Header.CreateHeader(Versions.FoxBaseDBase3NoMemo);
            Fields = new List<Field>();
            Records = new List<Record>();
        }

        public uint HeaderRowCount => header.RowCount;
        public Versions HeaderVersion => header.Version;
        public Encoding HeaderEncoding => header.Encoding;
        public DateTime HeaderLastUpdate => header.LastUpdate;

        public List<Field> Fields { get; }
        public List<Record> Records { get; }
        public int RowCount => Records.Count;
        public object this[int r, int c] => Records[r].Data[c];
        public object this[int r, string c]
        {
            get
            {
                var idx = Fields.FindIndex(f => f.Name.Equals(c, StringComparison.InvariantCultureIgnoreCase));
                return Records[r].Data[idx];
            }
        }

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
            var fi = new FileInfo(path);
            reportProgress(0);
            TableName = fi.Name.Split('.')[0];
            FilePath = fi.FullName;

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

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var peekChar = reader.PeekChar();
                if (peekChar == -1) break;
                if (peekChar == EOF) break;

                var record = new Record(reader, header, Fields, memoData);
                if (record.Data.Count > 0)
                {
                    Records.Add(record);
                }
                reportProgress(Records.Count, (int)HeaderRowCount);
            }
        }

        DataTable dtCache = null;
        public DataTable ToDataTable()
        {
            if (dtCache != null) return dtCache;

            dtCache = new DataTable(TableName);
            foreach (var v in Fields)
            {
                var t = v.GetNativeType();

                if (v.Type == FieldType.Logical) t = typeof(bool);
                var cln = dtCache.Columns.Add(v.Name, t);
                cln.AllowDBNull = true;
            }

            foreach (var r in Records)
            {
                if (r.Deleted) continue;
                dtCache.Rows.Add(r.Data.ToArray());
            }

            return dtCache;
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
            sb.AppendLine($"public record {TableName}");
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

                var field = $"    public {typeName} {f.Name} {{get ; set; }}";
                sb.AppendLine(field);
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public string ExportCreateTable(bool includeExample = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE TABLE {TableName} (");

            string[] exampleData = new string[Fields.Count];
            if (includeExample) exampleData = getExampleData();

            for (int i = 0; i < Fields.Count; i++)
            {
                var f = Fields[i];
                string typeName = buildSqlTypeName(f);

                string example = exampleData[i];
                var field = $"  {f.Name} {typeName}, {(string.IsNullOrEmpty(example) ? "" : $" -- Example: `{example}`")} ";
                sb.AppendLine(field);
            }
            sb.AppendLine(");");

            return sb.ToString();
        }

        /// <summary>
        /// Returns longest value for each column in the first 25 rows
        /// </summary>
        private string[] getExampleData()
        {
            string[] data = new string[Fields.Count];
            for (int r = 0; r < 25 && r < Records.Count; r++)
            {
                for (int i = 0; i < Fields.Count; i++)
                {
                    var val = Records[r].Data[i]?.ToString();

                    if (val == null) continue;
                    if (data[i] == null) data[i] = val;
                    if (data[i].Length < val.Length) data[i] = val;
                }

            }
            return data;
        }

        private string buildSqlTypeName(Field f)
        {
            switch (f.Type)
            {
                case FieldType.Float:
                    return $"FLOAT ({f.Length},{f.Precision})";
                case FieldType.Double:
                    return $"DOUBLE ({f.Length},{f.Precision})";
                case FieldType.Numeric:
                    return $"NUMERIC ({f.Length},{f.Precision})";

                case FieldType.Character:
                    return $"CHAR ({f.Length})";

                default:
                    return f.Type.ToString().ToUpper();
            }
        }

        // Enable Foreach
        public IEnumerator<DataRow> GetEnumerator()
        {
            return ToDataTable().Rows.Cast<DataRow>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ToDataTable().Rows.GetEnumerator();
        }

        public static Reader Open(string Path, IProgress<int> Progress = null, Encoding encoding = null)
        {
            if (encoding == null) encoding = DefaultEncoding;

            Reader t = new Reader();
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
            Reader t = new Reader();

            if (Progress != null)
            {
                t.LoadProgressChanged += (s, e) => Progress.Report(e.ProgressPercentage);
            }
            if (t.Encoding == null) t.Encoding = Encoding.Default;
            t.read(Path);
            return t.ToDataTable();
        }

        public static uint GetRowCount(string fullName)
        {
            var db = new Reader();
            using (FileStream stream = File.Open(fullName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Process reader
                    // Get Memo data
                    // Get Fields
                    // reposition the cursor
                    // read data

                    db.readHeader(reader);
                }
            }
            return db.HeaderRowCount;
        }

    }
}
