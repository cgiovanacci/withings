using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;

namespace Withings
{
    public class WithingsClient
    {
        private string consumerKey;
        private string consumerSecret;
        private UserCredentials userCredentials;
        private IRestClient restClient;
        private string baseApiUrl = "http://wbsapi.withings.net";

        public WithingsClient(string consumerKey, string consumerSecret, UserCredentials userCredentials)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.userCredentials = userCredentials;
            this.restClient = new RestClient(baseApiUrl);
            restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(this.consumerKey, this.consumerSecret,
                                                                                    userCredentials.OauthToken, userCredentials.OauthTokenSecret);
            ((OAuth1Authenticator)restClient.Authenticator).ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;
        }

        public List<MeasureGroup> GetMeasures(DateTime lastUpdate)
        {
            RestRequest request = GetMeasureBaseRequest();
            AddMeasureParameters(request, lastUpdate);
            IRestResponse response = this.restClient.Execute(request);
            return DeserializeMeasuresResponse(response);            
        }

        public List<MeasureGroup> DeserializeMeasuresResponse(IRestResponse response)
        {
            return WithingsResourceResponse.DeserializeMeasuresResponse(response);
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        private RestRequest GetMeasureBaseRequest()
        {
            RestRequest request = new RestRequest(string.Format("/measure"), Method.GET);
            request.AddParameter("action", "getmeas");
            return request;

        }

        private void AddMeasureParameters(RestRequest request, DateTime lastUpdate)
        {
            request.AddParameter("lastupdate", ToUnixTime(lastUpdate));
        }

    }
}