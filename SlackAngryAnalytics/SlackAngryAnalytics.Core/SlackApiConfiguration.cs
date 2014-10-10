using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SlackAngryAnalytics.Core
{
    public class SlackApiConfiguration
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string SlackSite { get; set; }
        public string SlackSiteApiDir
        {
            get { return SlackSite + @"/api"; }
        }
        public string TokenTemplate { get { return "token={0}"; } }

        public static SlackApiConfiguration BuildFromSecret()
        {
            string secret = ConfigurationManager.AppSettings["ClientSecret"];
            string slackSite = ConfigurationManager.AppSettings["SlackSite"];
            if (secret == null || slackSite == null)
            {
                throw new ConfigurationErrorsException("Config is missing.");
            }
            var result = new SlackApiConfiguration() {ClientSecret = secret,SlackSite = slackSite};
            return result;
        }
    }
}
