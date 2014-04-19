using System;
using System.Web;
using System.Configuration;
using System.IO;

namespace weixin.HttpHandler
{
    public class MP3Handler : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //在此处写入您的处理程序实现。
            string paramKey = ConfigurationManager.AppSettings["mp3ParamKey"];//参数名
            string paramValue = context.Server.UrlDecode(context.Request[paramKey]);//参数值
            if (paramValue == ConfigurationManager.AppSettings["mp3Token"])
            {
                string filePath = context.Request.FilePath;
                string fileFullPath = context.Server.MapPath(filePath);
                string fileName = filePath.Substring(filePath.LastIndexOf("/")+1);
                FileInfo file = new FileInfo(fileFullPath);
                if (file.Exists)
                {
                    context.Response.Clear();
                    context.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    context.Response.AddHeader("Content-Length", file.Length.ToString( ));
                    context.Response.ContentType = "audio/mp3; charset=gb2312";
                    context.Response.Filter.Close( );
                    context.Response.WriteFile(file.FullName);
                    context.Response.End( );
                }
            }
        }

        #endregion
    }
}
