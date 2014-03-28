// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��03��14�� 13:21
//  
//  �޸��ڣ�2013��03��14�� 13:57
//  �ļ�����NewArchitecture/Dev.DotNetOpenAuth.AspNetExtend/SinaClient.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System;
using System.Collections.Generic;
using Dev.Comm.Net;
using Dev.DotNetOpenAuth.AspNetExtend.Client.SinaModel;
using DotNetOpenAuth.AspNet.Clients;

namespace Dev.DotNetOpenAuth.AspNetExtend.Client
{
    /// <summary>
    ///   The Sina client.
    /// </summary>
    public sealed class SinaClient : OAuth2Client
    {
        private long Uid;
        //https://api.weibo.com/oauth2/authorize?client_id=123050457758183&redirect_uri=http://www.example.com/response&response_type=code

        /// <summary>
        ///   The authorization endpoint.
        /// </summary>
        private const string AuthorizationEndpoint = "https://api.weibo.com/oauth2/authorize";

        /// <summary>
        ///   The token endpoint.
        /// </summary>
        private const string TokenEndpoint = "https://api.weibo.com/oauth2/access_token";


        private const string UserDataEndpoint = "https://api.weibo.com/2/users/show.json";

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
        public SinaClient(string appId, string appSecret)
            : base("Sina")
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
            var uriBuilder = new UriBuilder(AuthorizationEndpoint);
            uriBuilder.AppendQueryArgs(new Dictionary<string, string>
                                           {
                                               {
                                                   "client_id",
                                                   this.appId
                                               },

                                               {
                                                   "redirect_uri",
                                                   returnUrl.AbsoluteUri
                                               }
                                               ,
                                               {
                                                   "response_type", "code"
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
            UriBuilder uriBuilder = new UriBuilder(UserDataEndpoint);
            uriBuilder.AppendQueryArgs(new Dictionary<string, string>
                                           {
                                               {"uid", this.Uid.ToString()},
                                               {"access_token", accessToken},
                                           });


            var text = Http.GetUrl(uriBuilder.ToString());


            var user = JsonHelper<User>(text);


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.AddItemIfNotEmpty("id", user.id.ToString());
            dictionary.AddItemIfNotEmpty("access_token", accessToken);
            dictionary.AddItemIfNotEmpty("name", user.name);


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
            //            client_id  true  string  ����Ӧ��ʱ�����AppKey��  
            //client_secret  true  string  ����Ӧ��ʱ�����AppSecret��  
            //grant_type  true  string  ��������ͣ���дauthorization_code  


            //grant_typeΪauthorization_codeʱ 

            //��ѡ 

            //���ͼ���Χ 

            //˵�� 

            //code  true  string  ����authorize��õ�codeֵ��  
            //redirect_uri  true  string  �ص���ַ��������ע��Ӧ����Ļص���ַһ�¡�  


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
                var token = JsonHelper<AccessToken>(text);
                this.Uid = token.uid;
                result = token.access_token;
            }

            return result;
        }


        private T JsonHelper<T>(string text)
        {
            return Dev.Comm.JsonConvert.ToJsonObject<T>(text);
            //return Open.Sina2SDK.JsonHelper.DeserializeToObj<T>(text);
        }

        /// <summary>
        ///   Converts any % encoded values in the URL to uppercase.
        /// </summary>
        /// <param name="url"> The URL string to normalize </param>
        /// <returns> The normalized url </returns>
        /// <example>
        ///   NormalizeHexEncoding("Login.aspx?ReturnUrl=%2fAccount%2fManage.aspx") returns "Login.aspx?ReturnUrl=%2FAccount%2FManage.aspx"
        /// </example>
        /// <remarks>
        ///   There is an issue in Sina whereby it will rejects the redirect_uri value if
        ///   the url contains lowercase % encoded values.
        /// </remarks>
        private static string NormalizeHexEncoding(string url)
        {
            char[] array = url.ToCharArray();
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i] == '%')
                {
                    array[i + 1] = char.ToUpperInvariant(array[i + 1]);
                    array[i + 2] = char.ToUpperInvariant(array[i + 2]);
                    i += 2;
                }
            }
            return new string(array);
        }
    }
}