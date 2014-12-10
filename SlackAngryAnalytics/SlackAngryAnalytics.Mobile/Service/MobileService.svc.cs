using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SlackAngryAnalytics.Core.Entities;
using SlackAngryAnalytics.Core.Helpers;
using SlackAngryAnalytics.Core.RestVM;

namespace SlackAngryAnalytics.Mobile.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MobileService : IMobileService
    {
        private readonly ISlackRestService _slackService;

        public MobileService()
        {
            _slackService=new SlackRestService();
        }
        public ChannelListVM GetChannelList()
        {
            return _slackService.GetAllChannels();
        }

        public MessageHistoryVM GetAllHistory(string channelId)
        {
            MessageHistoryVM result=new MessageHistoryVM();
            
            MessageHistoryVM wholeFetch = new MessageHistoryVM();
            MessageHistoryVM oneFetch = new MessageHistoryVM();
            oneFetch = _slackService.GetAllMessagesForAChannel(channelId, startTime: DateTime.Now - new TimeSpan(365, 0, 0, 0), endTime: DateTime.Now);
            var users = _slackService.GetAllUsers();
            var userMapping = users.Members.ToDictionary(o => o.Id);
            wholeFetch.Messages = new List<Message>();
            wholeFetch.Messages.AddRange(oneFetch.Messages);
            while (oneFetch.HasMore)
            {
                var nextFetchStart = oneFetch.Messages.Max(m => m.TimeStamp);
                oneFetch = _slackService.GetAllMessagesForAChannel("C024T5KRM", nextFetchStart, endTime: DateTime.Now);
                wholeFetch.Messages.AddRange(oneFetch.Messages);
            }
            wholeFetch.Messages = wholeFetch.Messages.OrderBy(m => m.TimeStamp).ToList();
            //Assert.IsTrue(wholeFetch.Messages.Count > 0);
            List<string> fword = new List<string>() { "fuck", "fck", "wtf", "wth", "shit", "damn" };
            var messages = wholeFetch.Messages;
            var test1 = messages.Where(m => m.CompositeMessage != null && !string.IsNullOrEmpty(m.CompositeMessage.Text)).ToList();
            var f1 = test1.Where(m => m.CompositeMessage.Text.ToLower().ContainsAny(fword.ToArray())).ToList();

            var test2 = messages.Where(m => m.Text != null && !string.IsNullOrEmpty(m.Text)).ToList();
            var f2 = test2.Where(m => m.Text.ToLower().ContainsAny(fword.ToArray()) && m.User != null).OrderBy(f => f.User).ThenByDescending(o=>o.TimeStamp).ToList();
            //foreach (Message m in f2)
            //{
            //    Debug.WriteLine(m.User);
            //    Debug.WriteLine(userMapping[m.User].Name + ":" + m.Text);
            //}
            
            result.HasMore = false;
            result.Messages = f2;
            return result;

        }
    }
}
