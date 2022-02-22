using System;
using System.Collections.Generic;
using System.IO;

namespace DBF.Reader
{
    public class Record
    {
        public List<object> Data { get; }

        public bool Deleted { get; private set; }

        public object this[int index] => Data[index];

        internal Record(BinaryReader reader, Header header, List<Field> fields, byte[] memoData)
        {
            Data = new List<object>();

            // Get marker
            byte marker = reader.ReadByte();
            Deleted = marker == '*';
            // .. and data
            byte[] row = reader.ReadBytes(header.RecordLen - 1);

            int offset = 0;
            foreach (var field in fields)
            {
                // Copy bytes from record buffer into field buffer.
                byte[] buffer = new byte[field.Length];
                Array.Copy(row, offset, buffer, 0, field.Length);
                offset += field.Length;

                var encoder = DataTypes.DataType.GetData(field.Type);
                Data.Add(encoder.Read(header, buffer, memoData));
            }
        }
    }
}
