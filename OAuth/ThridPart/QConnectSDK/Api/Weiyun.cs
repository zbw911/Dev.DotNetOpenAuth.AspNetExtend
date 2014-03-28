using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QConnectSDK.Authenticators;
using QConnectSDK.Models;

namespace QConnectSDK.Api
{
    public partial class RestApi
    {
        public void Uploadfile()
        {
        }


        /// <summary>
        /// 获取库视图支持的类型
        /// </summary>
        /// <param name="appId">第三方接入ID</param>         
        /// <returns></returns>
        public GetMediaTypeResult GetLibraryType()
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetLibraryTypeRequest(context.Config.GetAppKey());
            var response = Execute(request);
            var payload = Deserialize<GetMediaTypeResult>(response.Content);
            return payload;
        }
    }
}
