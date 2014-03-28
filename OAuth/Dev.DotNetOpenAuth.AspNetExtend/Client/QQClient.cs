using System;
using System.Collections.Generic;
using Dev.Comm.Net;
using Dev.DotNetOpenAuth.AspNetExtend.Client.QQModel;
using DotNetOpenAuth.AspNet.Clients;

namespace Dev.DotNetOpenAuth.AspNetExtend.Client
{
    public class QQClient : OAuth2Client
    {
        private long Uid;

        /// <summary>
        ///   The authorization endpoint.
        /// </summary>
        private const string AuthorizationEndpoint = " https://graph.qq.com/oauth2.0/authorize";

        /// <summary>
        ///   The token endpoint.
        /// </summary>
        private const string TokenEndpoint = "https://graph.qq.com/oauth2.0/token";

        private const string UserOpenidEndpoint = "https://graph.qq.com/oauth2.0/me";

        private const string UserDataEndpoint = "https://graph.qq.com/user/get_user_info";

        /// <summary>
        ///   The _app id.
        /// </summary>
        private readonly string appId;

        /// <summary>
        ///   The _app secret.
        /// </summary>
        private readonly string appSecret;

        /// <summary>
        ///   Initializes a new instance of the <see cref="T:DotNetOpenAuth.AspNet.Clients.SinaClient" /> class.
        /// </summary>
        /// <param name="appId"> The app id. </param>
        /// <param name="appSecret"> The app secret. </param>
        public QQClient(string appId, string appSecret)
            : base("QQ")
        {
            if (appId == null) throw new ArgumentNullException("appId");
            if (appSecret == null) throw new ArgumentNullException("appSecret");

            this.appId = appId;
            this.appSecret = appSecret;
        }

        /// <summary>
        ///   The get service login url.
        /// </summary>
        /// <param name="returnUrl"> The return url. </param>
        /// <returns> An absolute URI. </returns>
        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {

            /*
             * response_type  必须  授权类型，此值固定为“code”。  
client_id  必须  申请QQ登录成功后，分配给应用的appid。  
redirect_uri  必须  成功授权后的回调地址，必须是注册appid时填写的主域名下的地址，建议设置为网站首页或网站的用户中心。注意需要将url进行URLEncode。
 
state  必须  client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回。请务必严格按照流程检查用户与state参数状态的绑定。 

             * */
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
                                               },
                                               {
                                                   "state","state"
                                               }
                                           });

            return uriBuilder.Uri;
        }

        /// <summary>
        ///   The get user data.
        /// </summary>
        /// <param name="accessToken"> The access token. </param>
        /// <returns> A dictionary of profile data. </returns>
        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            UriBuilder uriBuilder = new UriBuilder(UserOpenidEndpoint);
            uriBuilder.AppendQueryArgs(new Dictionary<string, string>
                                           {
                                               //{"uid", this.Uid.ToString()},
                                               {"access_token", accessToken},
                                           });


            var text = Http.GetUrl(uriBuilder.ToString());


            var openid = GetUserOpenId(text);


            //var user = JsonHelper<User>(text);


            //           https://graph.qq.com/user/get_user_info? 
            //access_token=*************&
            //oauth_consumer_key=12345& 
            //openid=****************&
            //format=json 

            UriBuilder builderGetUserdata = new UriBuilder(UserDataEndpoint);
            builderGetUserdata.AppendQueryArgs(new Dictionary<string, string>
                                           { {"access_token", accessToken},
                                               {"oauth_consumer_key", this.appId},
                                              {"openid", openid},
                                                 {"format", "json"},
                                           });


            var userjson = Http.GetUrl(builderGetUserdata.ToString());

            var strJson = CleanJsonStr(userjson);

            var user = JsonHelper<User>(strJson);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.AddItemIfNotEmpty("id", openid);
            dictionary.AddItemIfNotEmpty("access_token", accessToken);
            dictionary.AddItemIfNotEmpty("username", user.Nickname);
            dictionary.AddItemIfNotEmpty("face", user.Figureurl);

            return dictionary;
        }

        /// <summary>
        ///   Obtains an access token given an authorization code and callback URL.
        /// </summary>
        /// <param name="returnUrl"> The return url. </param>
        /// <param name="authorizationCode"> The authorization code. </param>
        /// <returns> The access token. </returns>
        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            /*
             * grant_type  必须  授权类型，此值固定为“authorization_code”。  
    client_id  必须  申请QQ登录成功后，分配给网站的appid。  
    client_secret  必须  申请QQ登录成功后，分配给网站的appkey。  
    code  必须  上一步返回的authorization code。 
    如果用户成功登录并授权，则会跳转到指定的回调地址，并在URL中带上Authorization Code。
     例如，回调地址为www.qq.com/my.php，则跳转到：
    http://www.qq.com/my.php?code=520DD95263C1CFEA087****** 
    注意此code会在10分钟内过期。

 
    redirect_uri  必须  与上面一步中传入的redirect_uri保持一致。  

             * */


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
            ; // webClient.DownloadString(uriBuilder.Uri);
            if (string.IsNullOrEmpty(text))
            {
                result = null;
            }
            else
            {

                var token = GetUserAccessToken(text);
                //this.Uid = token.uid;
                result = token.AccessToken;
            }

            return result;
        }

        private OAuthToken GetUserAccessToken(string urlParams)
        {
            OAuthToken token = new OAuthToken();
            var parameters = urlParams.Split('&');
            foreach (var parameter in parameters)
            {
                var accessTokens = parameter.Split('=');
                if (accessTokens[0] == "access_token")
                {
                    token.AccessToken = accessTokens[1];

                }
                if (accessTokens[0] == "expires_in")
                {
                    token.ExpiresAt = Convert.ToInt32(accessTokens[1]);

                }
            }
            return token;
        }

        private string GetUserOpenId(string content)
        {
            var strJson = CleanJsonStr(content);
            var payload = JsonHelper<Callback>(strJson);
            return payload.openid;
        }

        private static string CleanJsonStr(string content)
        {
            string strJson = content.Replace("callback(", "").Replace(");", "");
            return strJson;
        }

        private T JsonHelper<T>(string text)
        {
            //return Dev.Comm.JsonConvert.ToJsonObject<T>(text);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
            //return Open.Sina2SDK.JsonHelper.DeserializeToObj<T>(text);
        }
    }
}