
using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Contrib;
using RestSharp.Authenticators.OAuth;

namespace Withings
{
    public class Authenticator
    {
        private string ConsumerKey;
        private string ConsumerSecret;
        public UserCredentials UserCredentials { get; set; }
        private string CallbackUrl;
        private string BaseUrl;

        public Authenticator(string BaseUrl, string ConsumerKey, string ConsumerSecret, string CallbackUrl, UserCredentials UserCredentials)
        {
            this.ConsumerKey = ConsumerKey;
            this.ConsumerSecret = ConsumerSecret;
            this.CallbackUrl = CallbackUrl;
            this.BaseUrl = BaseUrl;
            if (this.BaseUrl == null) this.BaseUrl = "https://oauth.withings.com";
            this.UserCredentials = UserCredentials;
        }

        /*
         Step one: get the temporary token from withings and generates the withings url the user will access to authorize our app         
         
         * First requests https://oauth.withings.com/account/request_token, signing it with Consumer Secret and adding the Consumer token through GET method
           This request returns a temporary request token and a temp. request token secret that are stored in the user credentials
         * 
         * Then generates and returns the url the caller must send the user to to authorize the token.
         */
        public string GenerateAuthUrlToken()
        {
            var baseUrl = this.BaseUrl;
            var client = new RestClient(baseUrl);
            client.Authenticator = OAuth1Authenticator.ForRequestToken(this.ConsumerKey, this.ConsumerSecret, this.CallbackUrl);
            ((OAuth1Authenticator)client.Authenticator).ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;

            var request = new RestRequest("account/request_token", Method.GET);
            var response = client.Execute(request);

            var qs = HttpUtility.ParseQueryString(response.Content);
            UserCredentials.OauthToken = qs["oauth_token"];
            UserCredentials.OauthTokenSecret = qs["oauth_token_secret"];

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Request Token Step Failed");

            request = new RestRequest("account/authorize");

            request.AddParameter("oauth_token", UserCredentials.OauthToken);
            var url = client.BuildUri(request).ToString();

            return url;
        }

        /* step two: exchange temp token for permanent one, updateand returns the UserCredentials */

        public UserCredentials ProcessApprovedAuthCallback(string TempAuthToken, string UserId)
        {
            var baseUrl = this.BaseUrl;
            var client = new RestClient(baseUrl);

            var request = new RestRequest("account/access_token", Method.POST);

            client.Authenticator = OAuth1Authenticator.ForAccessToken(
                this.ConsumerKey, this.ConsumerSecret, TempAuthToken, UserCredentials.OauthTokenSecret);

            var response = client.Execute(request);

            var qs = HttpUtility.ParseQueryString(response.Content);
            var oauth_token = qs["oauth_token"];
            var oauth_token_secret = qs["oauth_token_secret"];

            UserCredentials.OauthToken = oauth_token;
            UserCredentials.OauthTokenSecret = oauth_token_secret;
            UserCredentials.UserId = UserId;

            return UserCredentials;
        }


    }
}

