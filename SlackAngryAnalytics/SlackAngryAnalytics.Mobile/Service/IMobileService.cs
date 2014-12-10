using System.ServiceModel;
using System.ServiceModel.Web;
using SlackAngryAnalytics.Core.RestVM;

namespace SlackAngryAnalytics.Mobile.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMobileService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Channels", ResponseFormat = WebMessageFormat.Json)]
        ChannelListVM GetChannelList();
        // TODO: Add your service operations here

        [OperationContract]
        [WebGet(UriTemplate = "Channel/{channelId}/History", ResponseFormat = WebMessageFormat.Json)]
        MessageHistoryVM GetAllHistory(string channelId);
    }

    

    
}
