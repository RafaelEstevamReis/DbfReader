using System;
using System.Text;

namespace DBF.Reader.DataTypes
{
    public class Numeric : IDataType
    {
        private Numeric() { }

        static Numeric instance = null;
        public static Numeric Instance
        {
            get
            {
                if (instance == null) instance = new Numeric();
                return instance;
            }
        }        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            string text = Encoding.ASCII.GetString(Buffer).Trim();
            if (text.Length == 0) return null;
            float s;
            if (Single.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out s)) return s;
            
            return null;
        }
    }
}
