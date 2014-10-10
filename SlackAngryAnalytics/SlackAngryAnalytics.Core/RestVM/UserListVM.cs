using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using SlackAngryAnalytics.Core.Entities;

namespace SlackAngryAnalytics.Core.RestVM
{
    public class UserListVM:SlackRestResponseBodyBase
    {
        [DeserializeAs(Name = "members")]
        public List<User> Members { get; set; }
    }

    public class MessageHistoryVM : SlackRestResponseBodyBase
    {
        [DeserializeAs(Name = "messages")]
        public List<Message> Messages { get; set; }
        [DeserializeAs(Name = "has_more")]
        public bool HasMore { get; set; }
    }
}
