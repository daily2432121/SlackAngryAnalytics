using System;
using RestSharp.Deserializers;
using SlackAngryAnalytics.Core.Helpers;

namespace SlackAngryAnalytics.Core.Entities
{
    public class Message : ISlackEntity
    {
        [DeserializeAs(Name = "type")]
        public string Type { get; set; }
        [DeserializeAs(Name = "subType")]
        public string SubType { get; set; }
        [DeserializeAs(Name = "user")]
        public string User { get; set; }
        [DeserializeAs(Name = "text")]
        public string Text { get; set; }
        [DeserializeAs(Name = "ts")]
        public double TimeStampInUnixFormat { get; set; }

        public DateTime TimeStamp
        {
            get { return TimeStampInUnixFormat.FromUnixTime(); }
        }

        [DeserializeAs(Name = "edited")]
        public string Edited { get; set; }
        //[DeserializeAs(Name="attachments")]
        //public Attachment Attachments { get; set; }
        [DeserializeAs(Name = "message")]
        public Message CompositeMessage { get; set; }
    }
}