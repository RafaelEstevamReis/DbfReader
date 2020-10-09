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
        
        public object Read(byte[] Buffer, byte[] Memo)
        {
            string text = Encoding.ASCII.GetString(Buffer).Trim();
            if (text.Length == 0) return null;
            return text;
        }
    }
}
