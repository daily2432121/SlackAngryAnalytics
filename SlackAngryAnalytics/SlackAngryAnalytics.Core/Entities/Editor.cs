using System;

namespace SlackAngryAnalytics.Core.Entities
{
    public class Editor : ISlackEntity
    {
        public string UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}