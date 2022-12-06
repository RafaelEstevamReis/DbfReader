using System;
using System.IO;
using System.Text;

namespace Simple.DBF
{
    public abstract class Header
    {
        public Versions Version { get; set; }
        public DateTime LastUpdate { get; set; }
        public uint RowCount { get; set; }
        public ushort HeaderLen { get; set; }
        public ushort RecordLen { get; set; }

        public Encoding Encoding { get; internal set; }

        public static Header CreateHeader(Versions Version)
        {
            Header h = Version switch
            {
                Versions.FoxBaseDBase3NoMemo => new HeaderV3(),
                Versions.VisualFoxPro => new HeaderV3(),
                Versions.VisualFoxProWithAutoIncrement => new HeaderV3(),
                Versions.FoxPro2WithMemo => new HeaderV3(),
                Versions.FoxBaseDBase3WithMemo => new HeaderV3(),
                Versions.dBase4WithMemo => new HeaderV3(),
                _ => throw new NotImplementedException("Unsuported " + Version),
            };

            h.Version = Version;
            return h;
        }

        internal abstract void Read(BinaryReader reader);
    }
}
