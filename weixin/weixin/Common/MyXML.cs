using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace weixin.Common
{
    /// <summary>
    /// XML操作公共类
    /// </summary>
    public static class MyXML
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string filePath) where T : new()
        {
            T model = new T();
            if (!File.Exists(filePath))
            {
                return default(T);
            }
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (fs.Length == 0)
            {
                return default(T);
            }
            try
            {
                XmlSerializer xs = new XmlSerializer(model.GetType());
                model = (T)xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            return model;
        }
    }
}