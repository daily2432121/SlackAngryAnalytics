using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;

namespace SlackAngryAnalytics.Core.Entities
{
    public class User: ISlackEntity
    {
        [DeserializeAs(Name = "id")]
        public string Id { get; set; }
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
        [DeserializeAs(Name = "deleted")]
        public Boolean Deleted { get; set; }
        [DeserializeAs(Name = "members")]
        public string FirstName { get; set; }
        [DeserializeAs(Name = "real_name")]
        public string RealName { get; set; }
    }
}
