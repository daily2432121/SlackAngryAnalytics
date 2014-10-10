using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SlackAngryAnalytics.Core;
using SlackAngryAnalytics.Core.Entities;
using SlackAngryAnalytics.Core.Helpers;
using SlackAngryAnalytics.Core.RestVM;

namespace SlackAngryAnalytics
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SlackRestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SlackRestService.svc or SlackRestService.svc.cs at the Solution Explorer and start debugging.
    public class SlackRestService : ISlackRestService
    {
        public UserListVM GetAllUsers()
        {
            SlackApiConfiguration config = SlackApiConfiguration.BuildFromSecret();
            RestHelper helper = new RestHelper();
            helper.Init(config.SlackSiteApiDir,config.ClientSecret,config.TokenTemplate);
            UserListVM vm =helper.HttpsGet<UserListVM>("users.list?",useToken:true);
            return vm;
        }

        public ChannelListVM GetAllChannels()
        {
            SlackApiConfiguration config = SlackApiConfiguration.BuildFromSecret();
            RestHelper helper = new RestHelper();
            helper.Init(config.SlackSiteApiDir, config.ClientSecret, config.TokenTemplate);
            ChannelListVM vm = helper.HttpsGet<ChannelListVM>("channels.list?", useToken: true);
            return vm;
        }

        public MessageHistoryVM GetAllMessagesForAChannel(string channelId, DateTime startTime, DateTime endTime)
        {
            SlackApiConfiguration config = SlackApiConfiguration.BuildFromSecret();
            RestHelper helper = new RestHelper();
            helper.Init(config.SlackSiteApiDir, config.ClientSecret, config.TokenTemplate);
            string requestStr = string.Format("channels.history?channel={0}&oldest={1}&lastest={2}&count={3}&", channelId, startTime.ToUnixTime(), endTime.ToUnixTime(), 1000);
            MessageHistoryVM vm = helper.HttpsGet<MessageHistoryVM>(requestStr, useToken: true);
            return vm;
        }
    }
}
