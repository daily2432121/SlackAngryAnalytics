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
            UserListVM vm =helper.HttpsGet<UserListVM>("users.list",useToken:true);
            Debug.Assert(vm.Members.Count>0);
            return vm;
        }

        public List<Channel> GetAllChannels()
        {
            throw new NotImplementedException();
        }
    }
}
