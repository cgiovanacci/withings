using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Withings
{
    public class UserCredentials
    {
        public string OauthToken { get; set; }
        public string OauthTokenSecret { get; set; }
        public string UserId { get; set; }
    }
}
