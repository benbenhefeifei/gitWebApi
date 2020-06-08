using System;
using System.Linq;
using System.Xml;
using System.Configuration;

namespace com.xbao.tools.logger
{
    internal class Log4netAdapter : ILogger
    {
        // Switch=true|Name=Log4netAdapter
        private static string config = string.Empty;
        private log4net.ILog _log = null;

        public Log4netAdapter()
        {
            try
            {
                config = ConfigurationManager.AppSettings["Log:Log4net.Config"];
                if (string.IsNullOrEmpty(config))
                {
                    throw new ArgumentNullException("Log4net config params is null");
                }
                if (!string.IsNullOrEmpty(config) && config.Contains("|"))
                {
                    string[] setting = config.Split('|');
                    bool power = setting.First(s => s.StartsWith("Switch=")).ToLower() == "switch=true";
                    string name = (setting.First(s => s.StartsWith("Name=")) ?? "").Replace("Name=", "");
                    string path = (setting.First(s => s.StartsWith("Path=")) ?? "").Replace("Path=", "");
                    if (!power)
                    {
                        throw new ArgumentNullException("Log4net config params Switch is false");
                    }
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new ArgumentNullException("Log4net config params Name is NullOrEmpty");
                    }
                    log4net.Repository.ILoggerRepository loggerRepository = log4net.LogManager.CreateRepository("base");
                    loggerRepository.Threshold = log4net.Core.Level.Info;

                    if (string.IsNullOrEmpty(path))
                    {
                        log4net.Config.XmlConfigurator.Configure(loggerRepository);
                    }
                    else
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(path.Replace("AppStartup/", AppDomain.CurrentDomain.BaseDirectory));
                        XmlNode xmlNode = xmlDoc.SelectSingleNode("configuration").SelectSingleNode("log4net");
                        log4net.Config.XmlConfigurator.Configure(loggerRepository, (XmlElement)xmlNode);
                    }
                    _log = log4net.LogManager.GetLogger("base", name);
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 一般处理信息日志
        /// Level = info
        /// </summary>
        /// <param name="message">记录消息，支持 String.Format</param>
        /// <param name="args">String.Format 参数</param>
        public void Info(string message, params object[] args)
        {
            if (_log == null) { return; }
            if (_log.IsInfoEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (args != null && args.Length > 0)
                {
                    _log.InfoFormat(message, args);
                }
                else { _log.Info(message); }
            }
        }
        /// <summary>
        /// 警告信息日志
        /// </summary>
        /// <param name="message">记录消息，支持 String.Format</param>
        /// <param name="args">String.Format 参数</param>
        public void Warn(string message, params object[] args)
        {
            if (_log == null) { return; }
            if (_log.IsWarnEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (args != null && args.Length > 0)
                {
                    _log.WarnFormat(message, args);
                }
                else { _log.Warn(message); }
            }
        }
        /// <summary>
        /// 异常错误信息日志
        /// </summary>
        /// <param name="message">记录消息，支持 String.Format</param>
        /// <param name="args">String.Format 参数</param>
        public void Error(string message, params object[] args)
        {
            if (_log == null) { return; }
            if (_log.IsErrorEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (args != null && args.Length > 0)
                {
                    _log.ErrorFormat(message, args);
                }
                else { _log.Error(message); }
            }
        }
        /// <summary>
        /// 异常错误信息日志
        /// </summary>
        /// <param name="message">记录消息</param>
        /// <param name="exception">异常消息体</param>
        public void Error(string message, Exception exception)
        {
            if (_log == null) { return; }
            if (_log.IsErrorEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    _log.Error(message, exception);
                }
                else
                {
                    _log.Error(message);
                }
            }
        }

        public void Fatal(string message, params object[] args)
        {
            if (_log == null) { return; }
            if (_log.IsFatalEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (args != null && args.Length > 0)
                {
                    _log.FatalFormat(message, args);
                }
                else { _log.Fatal(message); }
            }
        }

        public void Fatal(string message, Exception exception)
        {
            if (_log == null) { return; }
            if (_log.IsFatalEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    _log.Fatal(message, exception);
                }
                else
                {
                    _log.Fatal(message);
                }
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (_log == null) { return; }
            if (_log.IsDebugEnabled && !string.IsNullOrWhiteSpace(message))
            {
                if (args != null && args.Length > 0)
                {
                    _log.DebugFormat(message, args);
                }
                else { _log.Debug(message); }
            }
        }

        public void Debug(string message, Exception exception)
        {
            if (_log == null) { return; }
            if (_log.IsDebugEnabled && !string.IsNullOrWhiteSpace(message) && exception != null)
            {
                if (exception != null)
                {
                    _log.Debug(message, exception);
                }
                else
                {
                    _log.Debug(message);
                }
            }
        }
    }
}
