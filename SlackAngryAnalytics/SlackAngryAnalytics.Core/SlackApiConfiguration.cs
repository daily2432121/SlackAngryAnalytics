using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackAngryAnalytics.Core
{
    public class SlackApiConfiguration
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }


        public static SlackApiConfiguration BuildFromSecret(IExecute<SlackApiConfiguration> handler)
        {
            SlackApiConfiguration result = handler.ExecuteAndReturn();
            return result;
        }
    }
}
