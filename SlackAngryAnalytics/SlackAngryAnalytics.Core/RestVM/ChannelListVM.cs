using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using SlackAngryAnalytics.Core.Entities;

namespace SlackAngryAnalytics.Core.RestVM
{
    public class ChannelListVM:SlackRestResponseBodyBase
    {
        [DeserializeAs(Name = "channels")]
        public List<Channel> Channels { get; set; }
    }
}
