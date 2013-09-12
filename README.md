withings
========

Withing for .NET

        // example uses static for simplicity, step 2 authenticator needs the temporary token obtained in step 1
        // so in a real app you want to persist it in between Step 1 and Step2
        public static Withings.Authenticator authenticator;

        private const string consumerKey = "YOUR APP KEY";
        private const string consumerSecret = "YOUR APP SECRET";

        // Step 1 action        
        // Authenticatiion Step 1 (after this step the authenticator.UserCredentials contains the temporary token)
        // replace http://localhost:50670/Step2 by the page you want Withings to redirect the user to
        
        authenticator = new Withings.Authenticator("https://oauth.withings.com/",
                consumerKey, consumerSecret, "http://localhost:50670/Step2", new Withings.UserCredentials());

        // send your user to this url for him to authorize your app
        string authorizeUrl = authenticator.GenerateAuthUrlToken();

        // Step 2 action        
        // Authentication step 2 (http://localhost:50670/Step2 in this example)
        string oauth_token = Request.QueryString["oauth_token"];
        string userid = Request.QueryString["userid"];

        // exchange temprary token for permanent one and store it in the authenticator.UserCredntials
        authenticator.ProcessApprovedAuthCallback(oauth_token, userid);
        
        // get the last 2 days of measurements
        WithingsClient withings_client = new WithingsClient(consumerKey, consumerSecret, authenticator.UserCredentials);
        List<MeasureGroup> measureGroupList = withings_client.GetMeasures(DateTime.Now.AddDays(-2));
        
        
        
