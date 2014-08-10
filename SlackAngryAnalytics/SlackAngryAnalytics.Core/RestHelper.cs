using System.Collections.Generic;
using RestSharp;

namespace SlackAngryAnalytics.Core
{
    public class RestHelper
    {
        public string Site { get; set; }
        public string Token { get; set; }
        public string TokenTemplate { get; set; }
        public void Init(string site, string token, string tokenTemplate)
        {
            Site = site;
            Token = token;
            TokenTemplate = tokenTemplate;
        }
        public T HttpsGet<T>(string partialUrl, bool useToken=false) where T:new()
        {
            string url = partialUrl;
            RestClient restClient = new RestClient(Site);
            if (useToken)
            {
                var tokenTail = string.Format(TokenTemplate, Token);
                url = url + tokenTail;
            }
            
            var request = new RestRequest(url, Method.GET);
            
            RestResponse<T> response = (RestResponse<T>)restClient.Execute<T>(request);
            return response.Data;
        }

        
    }
}
