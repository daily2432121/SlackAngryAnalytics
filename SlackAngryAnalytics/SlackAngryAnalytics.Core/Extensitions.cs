using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackAngryAnalytics.Core
{
    
    public static class Extensitions
    {
        public static DateTime ToLocalTime(this long timeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(timeStamp / 1000d)).ToLocalTime();
        }
    }
}
