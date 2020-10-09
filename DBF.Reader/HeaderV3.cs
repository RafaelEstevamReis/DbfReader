using System;

namespace DBF.Reader
{
    public class HeaderV3 : Header
    {
        internal override void Read(System.IO.BinaryReader reader)
        {
            Version = (Versions)reader.ReadByte();
            byte year = reader.ReadByte();
            if (year < 50) year += 100; // Good old millennium bug, i'll cut it in 50s
            LastUpdate = new DateTime(year + 1900, reader.ReadByte(), reader.ReadByte());
            RowCount = reader.ReadUInt32();
            HeaderLen = reader.ReadUInt16();
            RecordLen = reader.ReadUInt16();
            reader.ReadBytes(20);
        }
    }
}
