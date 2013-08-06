using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace EasyUtility
{
    public class EasyLog
    {
        private static ILog log;
        private static EasyLog logHelper = null;
        private static string configPath = "log4net.xml";
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ILog GetInstance()
        {
            logHelper = new EasyLog(configPath);

            return log;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static ILog GetInstance(string configPath)
        {
            logHelper = new EasyLog(configPath);

            return log;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configPath"></param>
        private EasyLog(string configPath)
        {
            if (!string.IsNullOrEmpty(configPath))
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configPath));
            }
            else
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }
    }
}
