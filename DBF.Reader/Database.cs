using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Simple.DBF
{
    public class Database
    {
        public Database(string directory)
        {
            Directory = directory;
        }
        public void Load(IProgress<int> progress = null)
        {
            var files = System.IO.Directory.GetFiles(Directory, "*.dbf");

            int tableCout = 0;
            int percent = 0;

            var info = files.AsParallel()
                            .Select(fName =>
                            {
                                // Load table
                                var tableInfo = TableInfo.Load(fName);
                                // set global encoding to table encoding
                                tableInfo.Encoding = Encoding;
                                // report progress
                                if (progress != null)
                                {
                                    var count = Interlocked.Increment(ref tableCout);
                                    var newPercent = (int)(count * 100f / files.Length);

                                    if (newPercent != percent)
                                    {
                                        percent = newPercent;
                                        progress.Report(percent);
                                    }
                                }
                                // return table
                                return tableInfo;
                            });

            Tables = info.ToArray();
        }
        /// <summary>
        /// Sets database's default encoding
        /// </summary>
        public Encoding Encoding { get; set; }
        public string Directory { get; private set; }
        public TableInfo[] Tables { get; private set; }

        public TableInfo this[string tableName]
            => Tables.First(t => t.Name.Equals(tableName, StringComparison.InvariantCultureIgnoreCase));

        public static Database Load(string directory, IProgress<int> progress = null)
        {
            var dt = new Database(directory);
            dt.Load(progress);
            return dt;
        }
    }
    public class TableInfo
    {
        private Reader cachedReaderRecords = null;
        private Reader cachedReaderPartial = null;

        public FileInfo FileInfo { get; set; }
        public Encoding Encoding { get; set; }
        public string Name { get; set; }
        public uint RowCount { get; set; }
        public Exception LoadError { get; set; }

        public Reader OpenTable(IProgress<int> progress = null, bool loadRecords = true)
        {
            // different caches
            if (loadRecords)
            {
                return cachedReaderRecords ??= Reader.Open(FileInfo.FullName, progress, Encoding, loadRecords: true);
            }
            else
            {
                // Alread have everything
                if (cachedReaderRecords != null) return cachedReaderRecords;

                return cachedReaderPartial ??= Reader.Open(FileInfo.FullName, progress, Encoding, loadRecords: false);
            }
        }

        public static TableInfo Load(string filePath)
        {
            var fi = new FileInfo(filePath);
            var ti = new TableInfo()
            {
                FileInfo = fi,
                Name = fi.Name,
            };

            try
            {
                ti.RowCount = Reader.GetRowCount(fi.FullName);
            }
            catch (Exception ex) { ti.LoadError = ex; }

            return ti;
        }
    }
}
