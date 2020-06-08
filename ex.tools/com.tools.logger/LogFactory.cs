
namespace com.xbao.tools.logger
{
    public static class LogFactory
    {
        #region 使用单例设计模式 获取 Memcached 缓存
        static ILogger _log4net = null;
        static readonly object _log4netLock = new object();
        /// <summary>
        /// log4net 内存集缓存机制
        /// </summary>
        public static ILogger log4net
        {
            get
            {
                if (_log4net == null)
                {
                    lock (_log4netLock)
                    {
                        if (_log4net == null)
                        {
                            _log4net = new Log4netAdapter();
                        }
                    }
                }
                return _log4net;
            }
        }
        #endregion

        #region 使用单例设计模式 获取 Memcached 缓存
        static ILogger _clogger = null;
        static readonly object _cloggertLock = new object();
        /// <summary>
        /// log4bao 自定义文件日志
        /// </summary>
        public static ILogger log4bao
        {
            get
            {
                if (_clogger == null)
                {
                    lock (_cloggertLock)
                    {
                        if (_clogger == null)
                        {
                            _clogger = new CLogAdapter();
                        }
                    }
                }
                return _clogger;
            }
        }
        #endregion
    }
}
