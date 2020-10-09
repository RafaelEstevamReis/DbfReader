using System;
using System.Linq;
using System.Text;

namespace DBF.Reader.DataTypes
{
    public class Memo : IDataType
    {
        private Memo() { }

        static Memo instance = null;
        public static Memo Instance
        {
            get
            {
                if (instance == null) instance = new Memo();
                return instance;
            }
        }
        
        public object Read(byte[] Buffer, byte[] Memo)
        {
            int index;
            if (Buffer.Length > 4)
            {
                string text = Encoding.ASCII.GetString(Buffer).Trim();
                if (text.Length == 0) return null;
                index = Convert.ToInt32(text);
            }
            else
            {
                index = BitConverter.ToInt32(Buffer, 0);
                if (index == 0) return null;
            }
            return readMemo(index, Memo);
        }
        private static string readMemo(int index, byte[] memoData)
        {
            UInt16 blockSize = BitConverter.ToUInt16(memoData.Skip(6).Take(2).Reverse().ToArray(), 0);
            int type = (int)BitConverter.ToUInt32(memoData.Skip(index * blockSize).Take(4).Reverse().ToArray(), 0);
            int length = (int)BitConverter.ToUInt32(memoData.Skip(index * blockSize + 4).Take(4).Reverse().ToArray(), 0);
            return Encoding.ASCII.GetString(memoData.Skip(index * blockSize + 8).Take(length).ToArray()).Trim();
        }
    }
}
