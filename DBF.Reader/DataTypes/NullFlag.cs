namespace DBF.Reader.DataTypes
{
    public class NullFlag : IDataType
    {
        private NullFlag() { }

        static NullFlag instance = null;
        public static NullFlag Instance
        {
            get
            {
                if (instance == null) instance = new NullFlag();
                return instance;
            }
        }

        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            return Buffer[0];
        }
    }
}
