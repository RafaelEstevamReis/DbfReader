using System;

namespace DBF.Reader.DataTypes
{
    public interface IDataType
    {
        object Read(Header header, byte[] Buffer, byte[] Memo);
    }
    internal class DataType
    {
        public static IDataType GetData(FieldType type)
        {
            switch (type)
            {
                case FieldType.Character:
                    return Character.Instance;
                case FieldType.Currency:
                    return Currency.Instance;
                case FieldType.Date:
                    return Date.Instance;
                case FieldType.DateTime:
                    return DateWithTime.Instance;
                case FieldType.Float:
                    return Float.Instance;
                case FieldType.Integer:
                    return Integer.Instance;
                case FieldType.Logical:
                    return Logical.Instance;
                case FieldType.Memo:
                    return Memo.Instance;
                case FieldType.NullFlags:
                    return NullFlag.Instance;
                case FieldType.Numeric:
                    return Numeric.Instance;
                default:
                    throw new NotImplementedException("Invalid type " + type);
            }
        }
    }
}
