using System;
using System.Text;

namespace Simple.DBF.DataTypes
{
    public class Float : IDataType
    {
        private Float() { }

        static Float instance = null;
        public static Float Instance
        {
            get
            {
                if (instance == null) instance = new Float();
                return instance;
            }
        }
        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            string text = Encoding.ASCII.GetString(Buffer).Trim();
            if (text.Length == 0) return null;
            return Convert.ToSingle(text);
        }
    }
}
