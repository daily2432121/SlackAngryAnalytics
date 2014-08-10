using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackAngryAnalytics.Core.Entities
{
    public class Channel : ISlackEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsArchived { get; set; }
        public string IsGeneral { get; set; }
        public List<string> Members  { get; set; }
        //C024T5KRM
    }
}
