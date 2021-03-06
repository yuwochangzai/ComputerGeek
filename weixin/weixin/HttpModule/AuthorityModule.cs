﻿using System;
using System.Web;

namespace weixin.HttpModule
{
    /// <summary>
    /// 目录权限模块
    /// </summary>
    public class AuthorityModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其 
            // 提供自定义日志记录实现的示例
            context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(Application_BeginRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此处放置自定义日志记录逻辑
        }
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            if (!CheckAuthority(application.Request))
            {
                application.CompleteRequest();
                application.Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                application.Context.Response.End();
            }
        }
        /// <summary>
        /// 校验Url路径权限
        /// </summary>
        /// <returns></returns>
        private bool CheckAuthority(HttpRequest request)
        {
            bool isAuthorized = false;
            string relativePath = request.RawUrl;
            isAuthorized = BLL.UnauthorizedPath.CheckAuthority(relativePath);           
            return isAuthorized;
        }
    }
}
