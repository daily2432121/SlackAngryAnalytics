using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackAngryAnalytics.Core.Entities;
using SlackAngryAnalytics.Core.Helpers;
using SlackAngryAnalytics.Core.RestVM;

namespace SlackAngryAnalytics.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void GetUserListTest()
        {
            SlackRestService service = new SlackRestService();
            var result = service.GetAllUsers();
            Assert.IsTrue(result.Members.Count>0);
            result.Members.ForEach(o=>Debug.WriteLine("UserId:{0}, Name:{1}, RealName:{2}",o.Id,o.Name,o.RealName));
        }

        [TestMethod]
        public void GetChannelListTest()
        {
            SlackRestService service = new SlackRestService();
            var result = service.GetAllChannels();
            Assert.IsTrue(result.Channels.Count > 0);
            
        }


        [TestMethod]
        public void GetChannelHistoryTest()
        {
            SlackRestService service = new SlackRestService();
            MessageHistoryVM wholeFetch = new MessageHistoryVM();
            MessageHistoryVM oneFetch =new MessageHistoryVM();
            oneFetch = service.GetAllMessagesForAChannel("C024T5KRM", startTime: DateTime.Now - new TimeSpan(365, 0, 0, 0), endTime: DateTime.Now);
            var users = service.GetAllUsers();
            var userMapping = users.Members.ToDictionary(o => o.Id);
            wholeFetch.Messages = new List<Message>();
            wholeFetch.Messages.AddRange(oneFetch.Messages);
            while (oneFetch.HasMore)
            {
                var nextFetchStart=oneFetch.Messages.Max(m => m.TimeStamp);
                oneFetch = service.GetAllMessagesForAChannel("C024T5KRM", nextFetchStart, endTime: DateTime.Now);
                wholeFetch.Messages.AddRange(oneFetch.Messages);
            }
            wholeFetch.Messages = wholeFetch.Messages.OrderBy(m => m.TimeStamp).ToList();
            Assert.IsTrue(wholeFetch.Messages.Count > 0);
            List<string> fword = new List<string>() {"fuck", "fck", "wtf", "wth", "shit", "damn"};
            var messages = wholeFetch.Messages;
            var test1= messages.Where(m => m.CompositeMessage != null && !string.IsNullOrEmpty(m.CompositeMessage.Text)).ToList();
            var f1=test1.Where(m => m.CompositeMessage.Text.ToLower().ContainsAny(fword.ToArray())).ToList();

            var test2 = messages.Where(m => m.Text != null && !string.IsNullOrEmpty(m.Text)).ToList();
            var f2 = test2.Where(m => m.Text.ToLower().ContainsAny(fword.ToArray()) && m.User!=null).OrderBy(f=>f.User).ToList();
            //foreach (Message m in f2)
            //{
            //    Debug.WriteLine(m.User);
            //    Debug.WriteLine(userMapping[m.User].Name + ":" + m.Text);
            //}
            f2.ForEach(o => Debug.WriteLine(userMapping[o.User].Name+":"+ o.Text));
            

        }
    }
}
