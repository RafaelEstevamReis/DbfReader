using System;

namespace DBF.Reader.DataTypes
{
    public class Integer : IDataType
    {
        private Integer() { }

        static Integer instance = null;
        public static Integer Instance
        {
            get
            {
                if (instance == null) instance = new Integer();
                return instance;
            }
        }

        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            return BitConverter.ToInt32(Buffer, 0);
        }
    }
}