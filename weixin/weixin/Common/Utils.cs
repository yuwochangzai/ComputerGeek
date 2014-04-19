using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weixin.Common
{
    /// <summary>
    /// 工具静态类
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 获取正则表达式匹配字符串匹配到的值
        /// </summary>
        /// <param name="str">待匹配字符串</param>
        /// <param name="regexExpression">正则表达式字符串</param>
        /// <returns>匹配到的结果字符串</returns>
        public static string GetStrByRegex(string str, string regexExpression)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexExpression);
            System.Text.RegularExpressions.Match match = regex.Match(str);
            return match.Value;
        }
        /// <summary>
        /// 获取正则表达式匹配字符串匹配到的数组
        /// </summary>
        /// <param name="str">待匹配字符串</param>
        /// <param name="regexExpression">正则表达式字符串</param>
        /// <returns>匹配到的结果字符串数组</returns>
        public static string[] GetArrByRegex(string str, string regexExpression)
        {
            List<string> list = new List<string>();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexExpression);
            System.Text.RegularExpressions.MatchCollection matches = regex.Matches(str);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                list.Add(match.Value);
            }
            return list.ToArray();
        }
        /// <summary>
        /// 校验字符串是否与正则表达式匹配
        /// </summary>
        /// <param name="str">待校验字符串</param>
        /// <param name="regexExpression">正则表达式字符串</param>
        /// <returns>true:匹配，false:不匹配</returns>
        public static bool IsMatch(string str, string regexExpression)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexExpression);
            System.Text.RegularExpressions.Match match = regex.Match(str);
            return regex.IsMatch(str);
        }
    }
}