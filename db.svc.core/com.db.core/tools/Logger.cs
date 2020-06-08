/***********************************************
 * 版权声明：2020-2222 
 * 编写作者：吴文吉
 * 功能描述：数据库操作日志
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace com.xbao.db.core.helper
{
    internal class Logger
    {
        const int LEVEL_INFO = 0;
        const int LEVEL_WARN = 2;
        const int LEVEL_ERROR = 1;
        const int LEVEL_FATAL = 3;
        const int LEVEL_DEBUG = 4;

        /// <summary>
        /// 日志所有等级
        /// </summary>
        private string[] LEVEL_ARR = new string[] { "Info", "Error", "Warn", "Fatal", "Debug" };

        private bool     _Switch    = false;
        private string   _Level     = string.Empty;
        private string   _Path      = string.Empty;
        private string   _Convert   = "%d [%t] %-5p %c ：%m %n";

        internal Logger()
        {
            // Switch=true|Level=Info|Path=AppStartup/db-logs/yyyyMMdd/dblog-HH.log
            string config = ConfigurationManager.AppSettings["Log:Db.Config"];
            if (string.IsNullOrEmpty(config)) { config = "Switch=true|Level=Info|Path=AppStartup/logs/yyyyMMdd/dblog-HH.log"; }

            string[] setting = config.Split('|');
            if (config.Contains("Switch=")) { _Switch = setting.First(s => s.StartsWith("Switch=")).ToLower() == "switch=true"; }
            if (config.Contains("Level=")) { _Level = setting.First(s => s.StartsWith("Level=")).Replace("Level=", ""); }
            if (config.Contains("Path=")) { _Path = setting.First(s => s.StartsWith("Path=")).Replace("Path=", ""); }
            if (config.Contains("Convert=")) { _Convert = setting.First(s => s.StartsWith("Convert=")).Replace("Convert=", ""); }

#if DEBUG
            if (string.IsNullOrEmpty(_Level)) { _Level = "Debug"; }
#elif RELEASE
            if (string.IsNullOrEmpty(_Level)) { _Level = "Error"; }
#endif
        }

        internal static Logger Instance { get { return new Logger(); } }

        /// <summary>
        /// 调试信息（用于调试的记录信息）
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        internal void Debug(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Debug"))
            {
                Write(LEVEL_DEBUG, message);
                if (exception != null)
                {
                    Write(LEVEL_DEBUG, exception.ToString());
                }
            }
        }
        /// <summary>
        /// 调试信息（用于调试的记录信息）
        /// </summary>
        /// <param name="msg">日志内容，支持占位符</param>
        /// <param name="args">占位符参数</param>
        internal void Debug(string msg, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Debug"))
            {
                if (args != null && args.Length > 0)
                {
                    Write(LEVEL_DEBUG, string.Format(msg, args));
                }
                else
                {
                    Write(LEVEL_DEBUG, msg);
                }
            }
        }
        /// <summary>
        /// 异常错误信息（程序错误）
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        internal void Error(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Error"))
            {
                Write(LEVEL_ERROR, message);
                if (exception != null)
                {
                    Write(LEVEL_ERROR, exception.ToString());
                }
            }
        }
        /// <summary>
        /// 异常错误信息（程序错误）
        /// </summary>
        /// <param name="msg">日志内容，支持占位符</param>
        /// <param name="args">占位符参数</param>
        internal void Error(string msg, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Error"))
            {
                if (args != null && args.Length > 0)
                {
                    Write(LEVEL_ERROR, string.Format(msg, args));
                }
                else
                {
                    Write(LEVEL_ERROR, msg);
                }
            }
        }

        /// <summary>
        /// 严重错误消息（导致系统宕机或短时间无法运行）
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        internal void Fatal(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Fatal"))
            {
                Write(LEVEL_FATAL, message);
                if (exception != null)
                {
                    Write(LEVEL_FATAL, exception.ToString());
                }
            }
        }
        /// <summary>
        /// 严重错误消息（导致系统宕机或短时间无法运行）
        /// </summary>
        /// <param name="msg">日志内容，支持占位符</param>
        /// <param name="args">占位符参数</param>
        internal void Fatal(string msg, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Fatal"))
            {
                if (args != null && args.Length > 0)
                {
                    Write(LEVEL_FATAL, string.Format(msg, args));
                }
                else
                {
                    Write(LEVEL_FATAL, msg);
                }
            }
        }

        /// <summary>
        /// 警告消息记录（错误但不影响系统运行）
        /// </summary>
        /// <param name="msg">日志内容，支持占位符</param>
        /// <param name="args">占位符参数</param>
        internal void Warn(string msg, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Warn"))
            {
                if (args != null && args.Length > 0)
                {
                    Write(LEVEL_WARN, string.Format(msg, args));
                }
                else
                {
                    Write(LEVEL_WARN, msg);
                }
            }
        }

        /// <summary>
        /// 一般操作消息记录（非错误消息）
        /// </summary>
        /// <param name="msg">日志内容，支持占位符</param>
        /// <param name="args">占位符参数</param>
        internal void Info(string msg, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Info"))
            {
                if (args != null && args.Length > 0)
                {
                    Write(LEVEL_INFO, string.Format(msg, args));
                }
                else
                {
                    Write(LEVEL_INFO, msg);
                }
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="type">日志级别</param>
        /// <param name="text">日志内容</param>
        private void Write(int type, string text)
        {
            if (string.IsNullOrEmpty(_Path))
            {
                _Path = "AppStartup/logs/yyyyMMdd/dblog-HH.log";
            }
            string newPath = _Path
                .Replace("yyyy", DateTime.Now.ToString("yyyy"))
                .Replace("MM", DateTime.Now.ToString("MM"))
                .Replace("dd", DateTime.Now.ToString("dd"))
                .Replace("HH", DateTime.Now.ToString("HH"));
            if (newPath.Contains("AppStartup"))
            {
                string appStartup = AppDomain.CurrentDomain.BaseDirectory.Replace("bin/Debug/netcoreapp3.1/", "");
                newPath = newPath.Replace("AppStartup/", appStartup);
            }
            try
            {
                string fileName = Path.GetFileName(newPath);
                string filePath = Path.GetDirectoryName(newPath);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = "dblog-HH.log".Replace("HH", DateTime.Now.ToString("HH"));
                }
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int thredId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                // %d [%t] %-5p %c ：%m %n
                string message = _Convert
                    .Replace("%d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                    .Replace("%t", thredId.ToString())
                    .Replace("%-5p", LEVEL_ARR[type].ToUpper())
                    .Replace("%c", "DBLogAdapter")
                    .Replace("%x", "NDC")
                    .Replace("%X", "MDC")
                    .Replace("%m", text)
                    .Replace("&lt;", "<").Replace("&gt;", ">")
                    .Replace("%n", "\r\n");

                File.AppendAllText(filePath + "/" + fileName, message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// 检查日志级别
        /// </summary>
        /// <param name="type">级别类型</param>
        /// <returns>true有效，false无效</returns>
        private Boolean CheckLevel(string type)
        {
            if (_Level.ToLower() == "all") { return true; }
            return Array.IndexOf(LEVEL_ARR, _Level) >= Array.IndexOf(LEVEL_ARR, type);
        }
    }   
}
