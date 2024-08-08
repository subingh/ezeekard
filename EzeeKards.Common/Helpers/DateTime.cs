namespace LogBook.Common.Helpers
{
    public class NepalTime
    {
        public static DateTime Now { get { return CurrentNST(); } }
      
        public static DateTime CurrentNST()
        {
            // Gets current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Gets Nepal Standard Time zone information
            TimeZoneInfo nepalTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time");

            // Convert current UTC time to Nepal Standard Time
            DateTime nepalTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, nepalTimeZone);

            return nepalTime;
        }

    }
}
