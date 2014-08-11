using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dev.DotNetOpenAuth.AspNetExtend;
using Dev.DotNetOpenAuth.AspNetExtend.Client;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
[assembly: PreApplicationStartMethod(typeof(PreApplicationStart), "Start")]
namespace Dev.DotNetOpenAuth.AspNetExtend
{
    /// <summary>
    /// 
    /// </summary>

    public static class PreApplicationStart
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(GoogleInterceptModule));
        }
    }

    /// <summary>
    /// 针对Google 返回值 Http的拦截，由于谷歌的Return_url只能用固定值，所以，改为使用
    /// </summary>
    public class GoogleInterceptModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += context_AcquireRequestState;
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            GoogleOAuth2Client.RewriteRequest();
        }

        public void Dispose()
        {

        }
    }
}
