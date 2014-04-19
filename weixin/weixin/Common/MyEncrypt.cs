using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weixin.Common
{
    /// <summary>
    /// 加密
    /// </summary>
    public static class MyEncrypt
    {
        public static string EncodeSHA1(string source)
        {
            string newStr = "";
            newStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(source, "SHA1");
            return newStr;
        }
    }
}