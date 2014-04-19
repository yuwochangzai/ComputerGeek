using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weixin.Model
{
    /// <summary>
    /// 无权限的路径
    /// </summary>
    public class UnauthorizedPath
    {
        /// <summary>
        /// 无权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 匹配的正则表达式
        /// </summary>
        public string Match { get; set; }
        /// <summary>
        /// 除了（匹配这一表达式的视作有权限的）
        /// </summary>
        public string Except { get; set; }
    }
}