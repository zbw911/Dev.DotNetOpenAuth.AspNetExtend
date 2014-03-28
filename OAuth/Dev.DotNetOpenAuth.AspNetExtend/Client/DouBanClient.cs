using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.AspNet.Clients;
using Dev.Comm.Net;


namespace Dev.DotNetOpenAuth.AspNetExtend.Client
{
    /// <summary>
    /// http://developers.douban.com/wiki/?title=oauth2
    /// douban
    /// 
    /// Impl by 王永良 ，2013 -7 -15
    /// </summary>
    public class DouBanClient : OAuth2Client
    {
        private long Uid;

        private const string AuthorizationEndpoint = "https://www.douban.com/service/auth2/auth";

        private const string TokenEndpoint = "https://www.douban.com/service/auth2/token";

        //private const string UserDataEndpoint = "https://api.douban.com/v2/user/~me";

        private const string UserDataEndpoint = "https://api.douban.com/v2/user/:name";

        private readonly string appId;

        private readonly string appSecret;

        private const string redirect_uri = "http://www.youxituan.com";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public DouBanClient(string appId, string appSecret)
            : base("DouBan")
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
                                                   //"redirect_uri",returnUrl.AbsoluteUri
                                                   "redirect_uri",redirect_uri
                                               }
                                               ,
                                               {
                                                   "response_type", "code"
                                               },
                                               {
                                                   //"scope","shuo_basic_r,shuo_basic_w,douban_basic_common"
                                                   "scope","scope"
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
            //throw new NotImplementedException();
            UriBuilder uriBuilder = new UriBuilder(UserDataEndpoint);

            //Dictionary<string, string> Headers = new Dictionary<string, string>();
            //Headers.AddItemIfNotEmpty("Authorization", "Bearer " + accessToken);
            //var text = Http.GetUrl(uriBuilder.ToString(), Headers);

           var uri =  UserDataEndpoint.Replace(":name",Uid.ToString());
           var text = Http.GetUrl(uri.ToString());

            var user = JsonHelper<DouBanUserInfo>(text);

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
                                                              //{"redirect_uri", returnUrl.AbsoluteUri}
                                                              {"redirect_uri",redirect_uri}
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
                var token = JsonHelper<DouBanAccessToken>(text);
                Uid = token.douban_user_id;
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
    public class DouBanAccessToken
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
        /// 用户id
        /// </summary>
        public long douban_user_id { get; set; }
    }

    public class DouBanUserInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Uid
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 头像小图
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alt { get; set; }

        /// <summary>
        /// 和当前登录用户的关系，friend或contact
        /// </summary>
        public string relation { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 城市id
        /// </summary>
        public string loc_id { get; set; }
        /// <summary>
        /// 所在地全称
        /// </summary>
        public string loc_name { get; set; }
        public string desc { get; set; }
        

    }

}
