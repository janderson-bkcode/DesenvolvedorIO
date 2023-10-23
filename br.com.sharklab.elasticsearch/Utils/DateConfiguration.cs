using System;

namespace br.com.sharklab.elasticsearch.Utils
{
    public static class DateConfiguration
    {
        public static DateTime GetBrazilianDateTime()
        {
            TimeZoneInfo brTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime brTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brTimeZone);

            return brTime;
        }
    }
}