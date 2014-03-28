using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace Open.Sina2SDK
{
    /// <summary>
    /// 支持Authentication Code，用户名和密码，公钥、密钥，Refresh Token四种获取Access Token方式。
    /// </summary>
    public class OAuthBase
    {
        #region Constructor
        public OAuthBase(string app_key, string app_secret, string redirect_uri)
        {
            this.App_Key = app_key;
            this.App_Secret = app_secret;
            this.Redirect_Uri = redirect_uri;
            this.HttpMethod = new HttpMethods();
        }

        public OAuthBase() :this(string.Empty,string.Empty,string.Empty)
        { }
        #endregion

        #region Fields
        /// <summary>
        /// App Key
        /// </summary>
        public string App_Key { get; set; }
        /// <summary>
        /// App Secret
        /// </summary>
        public string App_Secret { get; set; }
        /// <summary>
        /// 授权后要回调的URI，即接受code的URI。
        /// </summary>
        public string Redirect_Uri { get; set; }
        /// <summary>
        /// Post/Get方法
        /// </summary>
        public IHttpMethod HttpMethod { get;private set; }

        /// <summary>
        /// baseUrl
        /// </summary>
        public readonly string baseUrl = "https://api.weibo.com/2/{0}";
        /// <summary>
        /// 请求用户授权Token
        /// </summary>
        private readonly string authorizeUrl = "https://api.weibo.com/oauth2/authorize";
        /// <summary>
        /// 获取授权过的Access Token
        /// </summary>
        private readonly string tokenUrl = "https://api.weibo.com/oauth2/access_token";
        
        private AccessToken _Token;
        /// <summary>
        /// 请求OAuth服务返回包括Access Token等消息
        /// </summary>
        public AccessToken Token
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    _Token = null;
                    if (HttpContext.Current.Session["access_token"] != null)
                    {
                        _Token = HttpContext.Current.Session["access_token"] as AccessToken;
                    }
                    return _Token;
                }
                else
                {
                    return _Token;
                }
            }
           private set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["access_token"] = value;
                }
                else
                {
                    _Token = value;
                }
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 小马添加的
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="access_token"></param>
        public void SetAccessToken(long uid,string access_token) 
        {
            AccessToken tk = new AccessToken();
            tk.access_token = access_token;
            tk.expires_in = "60000";
            tk.uid = uid;
            _Token = tk;
        }



        /// <summary>
        /// 获取Authorization Code。
        /// </summary>
        public void GetAuthorizationCode()
        {
            string url = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", authorizeUrl, this.App_Key, this.Redirect_Uri); HttpContext.Current.Response.Redirect(url);
        }

        /// <summary>
        /// 使用Authentication Code获取Access Token。
        /// </summary>
        /// <param name="code">获得的Authorization Code。</param>
        public void GetAccessTokenByAuthorizationCode(string code)
        {
            string queryString = string.Format("grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}", code, this.App_Key, this.App_Secret, this.Redirect_Uri);

            this.Token= AccessTokenRequest(queryString);        }

        /// <summary>
        /// 转换json→AccessToken实例
        /// </summary>
        /// <param name="queryString">获取授权过的Access Token返回值</param>
        /// <returns></returns>
        private AccessToken AccessTokenRequest(string queryString)
        {
            var jsonResult = string.Empty;
            try
            {
                jsonResult = this.HttpMethod.HttpPost(tokenUrl, queryString);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream(), Encoding.UTF8);
                    jsonResult = reader.ReadToEnd();
                }
            }

            if (jsonResult.Contains("error"))
            {
                throw new WebException();
            }
            return jsonResult.ToEntity<AccessToken>();
        }
        #endregion
    }
}
