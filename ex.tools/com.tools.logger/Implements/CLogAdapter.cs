using System;
using System.IO;
using System.Linq;
using System.Configuration;

namespace com.xbao.tools.logger
{
    internal class CLogAdapter : ILogger
    {
        /// <summary>
        /// Switch=true|Items=|Path=E:/logs/yyyyMMdd/dd-HH.log
        /// </summary>
        private string[] _BaseLevel = new string[] { "Info,Warn,Error,Fatal,All,Debug" };
        private bool _Switch = true;
        private string _Level = "Error";
        private string _Path = string.Empty;
        private string _Convert = "%d [%t] %-5p %c ：%m %n";

        public CLogAdapter()
        {
            string config = ConfigurationManager.AppSettings["Log:Custom.Config"];
            if (!string.IsNullOrEmpty(config) && config.Contains("|"))
            {
                string[] setting = config.Split('|');
                if (config.Contains("Switch=")) { _Switch = setting.First(s => s.StartsWith("Switch=")).ToLower() == "switch=true"; }
                if (config.Contains("Level=")) { _Level = setting.First(s => s.StartsWith("Level=")).Replace("Level=", ""); }
                if (config.Contains("Path=")) { _Path = setting.First(s => s.StartsWith("Path=")).Replace("Path=", ""); }
                if (config.Contains("Convert=")) { _Convert = setting.First(s => s.StartsWith("Convert=")).Replace("Convert=", ""); }

#if DEBUG
                if (_Level == "All") { _Level = "Debug"; };
#elif RELEASE
                if (_Level == "Debug") { _Level = "All"; };
#endif
            }
        }

        /// <summary>
        /// 调试信息（用于调试的记录信息）
        /// </summary>
        public void Debug(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Debug"))
            {
                Write("Debug", message);
                if (exception != null)
                {
                    Write("Debug", exception.ToString());
                }
            }
        }
        /// <summary>
        /// 调试信息（用于调试的记录信息）
        /// </summary>
        public void Debug(string message, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Debug"))
            {
                if (args != null && args.Length > 0)
                {
                    Write("Debug", string.Format(message, args));
                }
                else
                {
                    Write("Debug", message);
                }
            }
        }
        /// <summary>
        /// 异常错误信息（程序错误）
        /// </summary>
        public void Error(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Error"))
            {
                Write("Error", message);
                if (exception != null)
                {
                    Write("Error", exception.ToString());
                }
            }
        }
        /// <summary>
        /// 异常错误信息（程序错误）
        /// </summary>
        public void Error(string message, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Error"))
            {
                if (args != null && args.Length > 0)
                {
                    Write("Error", string.Format(message, args));
                }
                else
                {
                    Write("Error", message);
                }
            }
        }
        /// <summary>
        /// 严重错误消息（导致系统宕机或短时间无法运行）
        /// </summary>
        public void Fatal(string message, Exception exception)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Fatal"))
            {
                Write("Fatal", message);
                if (exception != null)
                {
                    Write("Fatal", exception.ToString());
                }
            }
        }
        /// <summary>
        /// 严重错误消息（导致系统宕机或短时间无法运行）
        /// </summary>
        public void Fatal(string message, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Fatal"))
            {
                if (args != null && args.Length > 0)
                {
                    Write("Fatal", string.Format(message, args));
                }
                else
                {
                    Write("Fatal", message);
                }
            }
        }
        /// <summary>
        /// 警告消息记录（错误但不影响系统运行）
        /// </summary>
        public void Warn(string message, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Warn"))
            {
                if (args != null && args.Length > 0)
                {
                    Write("Warn", string.Format(message, args));
                }
                else
                {
                    Write("Warn", message);
                }
            }
        }
        /// <summary>
        /// 一般操作消息记录（非错误消息）
        /// </summary>
        public void Info(string message, params object[] args)
        {
            if (!_Switch) { return; }
            if (CheckLevel("Info"))
            {
                if (args != null && args.Length > 0)
                {
                    Write("Info", string.Format(message, args));
                }
                else
                {
                    Write("Info", message);
                }
            }
        }

        private void Write(string type, string text)
        {
            if (string.IsNullOrEmpty(_Path))
            {
                _Path = "AppStartup/logs/yyyyMMdd/uslog-HH.log";
            }

            string newPath = _Path
                .Replace("yyyy", DateTime.Now.ToString("yyyy"))
                .Replace("yy", DateTime.Now.ToString("yy"))
                .Replace("MM", DateTime.Now.ToString("MM"))
                .Replace("dd", DateTime.Now.ToString("dd"))
                .Replace("HH", DateTime.Now.ToString("HH"))
                .Replace("mm", DateTime.Now.ToString("mm"));
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
                    fileName = "clog-HH.log".Replace("HH", DateTime.Now.ToString("HH"));
                }
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                int thredId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                string message = _Convert
                    .Replace("%d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                    .Replace("%t", thredId.ToString())
                    .Replace("%-5p", type.ToUpper())
                    .Replace("%c", "UseLogAdapter")
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
            return Array.IndexOf(_BaseLevel, _Level) >= Array.IndexOf(_BaseLevel, type);
        }
    }
}
