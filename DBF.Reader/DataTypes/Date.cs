using System;
using System.Text;

namespace Simple.DBF.DataTypes
{
    public class Date : IDataType
    {
        private Date() { }

        static Date instance = null;
        public static Date Instance
        {
            get
            {
                if (instance == null) instance = new Date();
                return instance;
            }
        }        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            string text = Encoding.ASCII.GetString(Buffer).Trim();
            if (text.Length == 0) return null;

            if (text.StartsWith("0000")) text = "1900" + text.Substring(4);

            return DateTime.ParseExact(text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
