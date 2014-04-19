using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using weixin.Common;

namespace weixin
{
    public partial class _Default : System.Web.UI.Page
    {
        private static string token = ConfigurationManager.AppSettings["weixinToken"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.HttpMethod.ToUpper() == "POST")//post请求回复消息
                {
                    ResponseMsg();
                }
                else if (Request.HttpMethod.ToUpper() == "GET")//get请求验证微信
                {
                    ValidateWeiXin();
                }
            }
            catch (Exception ex)
            {
                MyLog.WriteErrorLog(ex.ToString());
            }
        }

        /// <summary>
        /// 校验请求是否来源于微信
        /// 加密/校验流程：
        /// 1. 将token、timestamp、nonce三个参数进行字典序排序
        /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
        /// 3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
        /// </summary>
        /// <returns></returns>
        private bool CheckSignature()
        {
            bool isFromWeiXin = false;
            if (!string.IsNullOrEmpty(Request["signature"]) && !string.IsNullOrEmpty(Request["timestamp"]) && !string.IsNullOrEmpty(Request["nonce"]) && !string.IsNullOrEmpty(Request["echostr"]))
            {
                string signature = Server.UrlDecode(Request["signature"]);//微信加密签名
                string timestamp = Server.UrlDecode(Request["timestamp"]);//时间戳
                string nonce = Server.UrlDecode(Request["nonce"]);//随机数
                string[] arrPara = new string[] { token, timestamp, nonce };
                Array.Sort(arrPara);//字典序排序
                string paras = string.Join("", arrPara);
                if (MyEncrypt.EncodeSHA1(paras).ToLower() == signature.ToLower())
                {
                    isFromWeiXin = true;
                }
            }
            return isFromWeiXin;
        }
        /// <summary>
        /// 验证微信Get请求
        /// </summary>
        private void ValidateWeiXin()
        {
            string echostr = Request.QueryString["echostr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echostr))
                {
                    Response.Write(echostr);
                    Response.End();
                }
            }
        }
        /// <summary>
        /// 回复消息
        /// </summary>
        private void ResponseMsg()
        {

        }
    }
}