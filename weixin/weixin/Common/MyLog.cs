using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace weixin.Common
{
    public static class MyLog
    {
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteErrorLog(string ex)
        {
            WriteLog(ex, "error");
        }
        /// <summary>
        /// 写历史消息
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteHisMsg(string msg)
        {
            WriteLog(msg, "msg");
        }
        /// <summary>
        /// 写业务消息
        /// </summary>
        /// <param name="biz"></param>
        public static void WriteBizMsg(string biz)
        {
            WriteLog(biz, "biz");
        }
        private static void WriteLog(string ex, string suffix)
        {
            try
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\log";
                DirectoryInfo di = new DirectoryInfo(strPath);
                if (!di.Exists)
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath += @"\" + DateTime.Now.ToString("yyyyMMdd") + suffix+".txt";
                using (FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter m_streamWriter = new StreamWriter(fs))
                    {
                        m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                        m_streamWriter.WriteLine(ex + "||||||" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        m_streamWriter.WriteLine("\r\n");
                        m_streamWriter.Flush();
                        m_streamWriter.Close();
                        fs.Close();
                    }
                }
            }
            catch
            {

            }
        }
    }
}