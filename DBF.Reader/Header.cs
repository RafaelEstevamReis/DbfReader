using System;
using System.IO;

namespace DBF.Reader
{
    public abstract class Header
    {
        public Versions Version { get; set; }
        public DateTime LastUpdate { get; set; }
        public uint RowCount { get; set; }
        public ushort HeaderLen { get; set; }
        public ushort RecordLen { get; set; }

        public static Header CreateHeader(Versions Version)
        {
            Header h;
            switch (Version)
            {
                case Versions.FoxBaseDBase3NoMemo:
                    h = new HeaderV3();
                    break;
                case Versions.VisualFoxPro:
                    h = new HeaderV3();
                    break;
                case Versions.VisualFoxProWithAutoIncrement:
                    h = new HeaderV3();
                    break;
                case Versions.FoxPro2WithMemo:
                    h = new HeaderV3();
                    break;
                case Versions.FoxBaseDBase3WithMemo:
                    h = new HeaderV3();
                    break;
                case Versions.dBase4WithMemo:
                    h = new HeaderV3();
                    break;
                default:
                    throw new NotImplementedException("Unsuported " + Version);
            }
            h.Version = Version;
            return h;
        }

        internal abstract void Read(BinaryReader reader);
    }
}
