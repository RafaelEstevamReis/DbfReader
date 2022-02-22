using System;

namespace Simple.DBF.DataTypes
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
        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            return BitConverter.ToSingle(Buffer, 0);
        }
    }
}
