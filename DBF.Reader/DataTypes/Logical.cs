using System.Text;

namespace DBF.Reader.DataTypes
{
    public class Logical : IDataType
    {
        private Logical() { }

        static Logical instance = null;
        public static Logical Instance
        {
            get
            {
                if (instance == null) instance = new Logical();
                return instance;
            }
        }

        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            string text = Encoding.ASCII.GetString(Buffer).Trim().ToUpper();
            if (text == "?") return null;
            return (text == "Y" || text == "T");
        }
    }
}