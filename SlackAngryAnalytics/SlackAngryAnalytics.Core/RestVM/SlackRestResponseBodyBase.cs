using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SlackAngryAnalytics.Core.RestVM
{
    public class SlackRestResponseBodyBase
    {
        [DeserializeAs(Name = "ok")]
        public Boolean Ok { get; set; }
        [DeserializeAs(Name = "error")]
        public string Error { get; set; }
    }


}
