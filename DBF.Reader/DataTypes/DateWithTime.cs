using System;

namespace Simple.DBF.DataTypes
{
    public class DateWithTime : IDataType
    {
        private DateWithTime() { }

        static DateWithTime instance = null;
        public static DateWithTime Instance
        {
            get
            {
                if (instance == null) instance = new DateWithTime();
                return instance;
            }
        }        
        public object Read(Header header, byte[] Buffer, byte[] Memo)
        {
            return ConvertFoxProToDateTime(Buffer);
        }
        private static DateTime ConvertFoxProToDateTime(byte[] buffer)
        {
            UInt32 dateData = BitConverter.ToUInt32(buffer, 0);
            int timeData = (int)BitConverter.ToUInt32(buffer, 4);

            DateTime jDate = JulianToDateTime(dateData);

            int hour = timeData / 3600000;
            timeData = timeData - hour * 3600000;
            int minute = timeData / 60000;
            timeData = timeData - minute * 60000;
            int second = timeData / 1000;

            return new DateTime(jDate.Year, jDate.Month, jDate.Day, hour, minute, second);
        }
        private static DateTime JulianToDateTime(long julianDate)
        {
            // https://en.wikipedia.org/wiki/Julian_day

            // Julian Date conversion
            if (julianDate == 0) return DateTime.MinValue;
            double p = Convert.ToDouble(julianDate);
            double s1 = p + 68569;
            double n = Math.Floor(4 * s1 / 146097);
            double s2 = s1 - Math.Floor(((146097 * n) + 3) / 4);
            double i = Math.Floor(4000 * (s2 + 1) / 1461001);
            double s3 = s2 - Math.Floor(1461 * i / 4) + 31;
            double q = Math.Floor(80 * s3 / 2447);
            double d = s3 - Math.Floor(2447 * q / 80);
            double s4 = Math.Floor(q / 11);
            double m = q + 2 - (12 * s4);
            double j = (100 * (n - 49)) + i + s4;
            return new DateTime(Convert.ToInt32(j), Convert.ToInt32(m), Convert.ToInt32(d));
        }
    }
}
