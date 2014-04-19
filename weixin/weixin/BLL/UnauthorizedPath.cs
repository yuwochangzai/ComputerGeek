using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weixin.Common;

namespace weixin.BLL
{
    /// <summary>
    /// 无权限目录处理类
    /// </summary>
    public  class UnauthorizedPath
    {
        // <summary>
        // 配置文件路径
        // </summary>
        private  static readonly string configPath = @"App_Data\UnauthorizedPath.xml";
        /// <summary>
        /// 全局无权限目录配置
        /// </summary>
        private static List<Model.UnauthorizedPath> ListUnauthorizedPath;
        /// <summary>
        /// 默认构造
        /// </summary>
        static UnauthorizedPath()
        {
            if (ListUnauthorizedPath == null || ListUnauthorizedPath.Count == 0)
            {               
                ListUnauthorizedPath = GetUnauthorizedPath();
            }
        }
        /// <summary>
        /// 获取无权限目录配置
        /// </summary>
        /// <returns></returns>
        private  static List<Model.UnauthorizedPath> GetUnauthorizedPath()
        {
            string rootPath = HttpContext.Current.Server.MapPath("~");
            string filePath = System.IO.Path.Combine(rootPath, configPath);
            List<Model.UnauthorizedPath> listPath = MyXML.Deserialize<List<Model.UnauthorizedPath>>(filePath);
            return listPath;
        }
        /// <summary>
        /// 校验Url路径权限
        /// </summary>
        /// <param name="rawUrl">应用程序相对路径</param>
        /// <returns></returns>
        public static bool CheckAuthority(string rawUrl)
        {
            bool isAuthorized = false;
            int index =ListUnauthorizedPath.FindIndex(u => Utils.IsMatch(rawUrl, u.Match)&&!Utils.IsMatch(rawUrl,u.Except));
            if (index == -1)//不在无权限配置里面，即有权限
            {
                isAuthorized = true;
            }
            return isAuthorized;
        }
    }
}