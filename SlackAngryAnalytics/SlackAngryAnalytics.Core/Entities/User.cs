using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackAngryAnalytics.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Boolean Deleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
