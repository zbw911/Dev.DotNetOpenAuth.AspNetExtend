using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.AspNet.Clients;
using Dev.Comm.Net;

namespace Dev.DotNetOpenAuth.AspNetExtend.Client
{
    /// <summary>
    /// 人人客户端
    /// http://wiki.dev.renren.com/wiki/Authentication
    ///  Impl by 王永良 ，2013 -7 -15
    /// </summary>
    public class RenRenClient : OAuth2Client
    {

        private long Uid;

        private const string AuthorizationEndpoint = "https://graph.renren.com/oauth/authorize";

        private const string TokenEndpoint = "https://graph.renren.com/oauth/token";

        //private const string UserDataEndpoint = "https://api.renren.com/v2/user/get";
        private const string UserDataEndpoint = "https://api.renren.com/v2/user/login/get";
        private readonly string appId;

        private readonly string appSecret;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public RenRenClient(string appId, string appSecret)
            : base("RenRen")
        {
            if (appId == null) throw new ArgumentNullException("appId");
            if (appSecret == null) throw new ArgumentNullException("appSecret");

            this.appId = appId;
            this.appSecret = appSecret;
        }


        /// <summary>
        /// Gets the full url pointing to the login page for this client. The url should include the specified return url so that when the login completes, user is redirected back to that url.
        /// </summary>
        /// <param name="returnUrl">The return URL. 
        ///             </param>
        /// <returns>
        /// An absolute URL. 
        /// </returns>
        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {
            var uriBuilder = new UriBuilder(AuthorizationEndpoint);
            uriBuilder.AppendQueryArgs(new Dictionary<string, string>
                                           {
                                               {
                                                   "client_id",this.appId
                                               },

                                               {
                                                   "redirect_uri",returnUrl.AbsoluteUri
                                               }
                                               ,
                                               {
                                                   "response_type", "code"
                                               }
                                           });

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Given the access token, gets the logged-in user's data. The returned dictionary must include two keys 'id', and 'username'.
        /// </summary>
        /// <param name="accessToken">The access token of the current user. 
        ///             </param>
        /// <returns>
        /// A dictionary contains key-value pairs of user data 
        /// </returns>
        protected override IDictionary<string, string> GetUserData(string accessToken)
        {

            UriBuilder uriBuilder = new UriBuilder(UserDataEndpoint);
            uriBuilder.AppendQueryArgs(new Dictionary<string, string>
                                           {
                                               //{"uid", this.Uid.ToString()},
                                               {"access_token", accessToken},
                                           });

            var text = Http.GetUrl(uriBuilder.ToString());
            text = text + ";";
            string strJson = text.Replace("{\"response\":", "").Replace("};", "");
            var user = JsonHelper<RenRenUser>(strJson);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.AddItemIfNotEmpty("id", user.id.ToString());
            dictionary.AddItemIfNotEmpty("access_token", accessToken);
            dictionary.AddItemIfNotEmpty("name", user.name);

            return dictionary;
        }

        /// <summary>
        /// Queries the access token from the specified authorization code.
        /// </summary>
        /// <param name="returnUrl">The return URL. 
        ///             </param><param name="authorizationCode">The authorization code. 
        ///             </param>
        /// <returns>
        /// The access token 
        /// </returns>
        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            UriBuilder uriBuilder = new UriBuilder(TokenEndpoint);
            var args = UrlUtilities.CreateQueryString(new Dictionary<string, string>
                                                          {
                                                              {"client_id", this.appId},
                                                              {"client_secret", this.appSecret},
                                                              {"grant_type", "authorization_code"},
                                                              {"code", authorizationCode},
                                                              {"redirect_uri", returnUrl.AbsoluteUri}
                                                          });
            string result;
            string text = Dev.Comm.Net.Http.PostUrl(uriBuilder.Uri.ToString(), args);
            // webClient.DownloadString(uriBuilder.Uri);
            if (string.IsNullOrEmpty(text))
            {
                result = null;
            }
            else
            {
                var token = JsonHelper<RenRenAccessToken>(text);
                result = token.access_token;
            }

            return result;
        }

        private T JsonHelper<T>(string text)
        {
            return Dev.Comm.JsonConvert.ToJsonObject<T>(text);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class RenRenAccessToken
    {
        /// <summary>
        /// 要获取的Access Token。
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Access Token的有效期，以秒为单位。
        /// </summary>
        public string expires_in { get; set; }

        /// <summary>
        /// 获取到的刷新token。
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class RenRenUser
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string id { get; set; }
        public _avatar avatar { get; set; }
        public int star { get; set; }
        public string basicInformation { get; set; }
        public string education { get; set; }
        public string work { get; set; }
        public string like { get; set; }
        public string emotionalState { get; set; }
    }

    public class _avatar
    {
        public string size { get; set; }
        public string url { get; set; }
    }

}
