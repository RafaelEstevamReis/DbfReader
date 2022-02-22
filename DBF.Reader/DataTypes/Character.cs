using System.Text;

namespace DBF.Reader.DataTypes
{
    public class Character : IDataType
    {

        private Character() { }

        static Character instance = null;
        public static Character Instance
        {
            get
            {
                if (instance == null) instance = new Character();
                return instance;
            }
        }
        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {            
            string text = header.Encoding.GetString(Buffer).Trim();
            if (text.Length == 0) return null;
            return text;
        }
    }
}
