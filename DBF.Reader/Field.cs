using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace DBF.Reader
{
    public class Field
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }
        public byte Length { get; set; }

        public byte Precision { get; set; }
        public byte WorkAreaID { get; set; }
        public byte Flags { get; set; }

        public Field(string name, FieldType type, byte length)
        {
            this.Name = name;
            this.Type = type;
            this.Length = length;
            this.Precision = 0;
            this.WorkAreaID = 0;
            this.Flags = 0;
        }
        internal Field(BinaryReader reader)
        {
            var bytesName = reader.ReadBytes(11);
            Name = Encoding.ASCII.GetString(bytesName).Split('\0')[0];

            Type = (FieldType)reader.ReadByte();
            reader.ReadBytes(4);
            Length = reader.ReadByte();
            Precision = reader.ReadByte();
            reader.ReadBytes(2); // reserved.
            WorkAreaID = reader.ReadByte();
            reader.ReadBytes(2); // reserved.
            Flags = reader.ReadByte();
            reader.ReadBytes(8);
        }

        public Type GetNativeType()
        {
            switch (Type)
            {
                case FieldType.Character:
                    return typeof(string);
                case FieldType.Currency:
                    return typeof(decimal);
                case FieldType.Numeric:
                    return typeof(float);
                case FieldType.Float:
                    return typeof(float);
                case FieldType.Date:
                    return typeof(DateTime);
                case FieldType.DateTime:
                    return typeof(DateTime);
                case FieldType.Double:
                    return typeof(double);
                case FieldType.Integer:
                    return typeof(int);
                case FieldType.Logical:
                    return typeof(bool?);
                case FieldType.Memo:
                    return typeof(string);
                case FieldType.NullFlags:
                    return typeof(byte);
                case FieldType.Picture:
                    return typeof(Bitmap);

                default:
                    return typeof(object);
            }
        }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}
