using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlackAngryAnalytics.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void GetUserTest()
        {
            SlackRestService service = new SlackRestService();
            var result = service.GetAllUsers();

        }
    }
}
