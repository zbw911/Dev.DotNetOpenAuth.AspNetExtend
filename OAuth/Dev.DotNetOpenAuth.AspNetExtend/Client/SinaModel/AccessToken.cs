using System.Collections.Generic;

namespace Dev.DotNetOpenAuth.AspNetExtend.Client.SinaModel
{
    #region 请求OAuth服务返回包括Access Token等消息类型。
    /// <summary>
    /// 请求OAuth服务返回包括Access Token等消息类型。
    /// </summary>
    public class AccessToken
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
        /// 会员ID
        /// </summary>
        public long uid { get; set; }
    }
    #endregion
 
}
