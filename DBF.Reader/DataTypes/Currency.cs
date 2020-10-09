using System;

namespace DBF.Reader.DataTypes
{
    public class Currency : IDataType
    {
        private Currency() { }

        static Currency instance = null;
        public static Currency Instance
        {
            get
            {
                if (instance == null) instance = new Currency();
                return instance;
            }
        }
        
        public object Read(byte[] Buffer, byte[] Memo)
        {
            return BitConverter.ToSingle(Buffer, 0);
        }
    }
}
