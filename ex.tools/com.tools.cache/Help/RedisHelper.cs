using System;
using System.Configuration;
using ServiceStack.Redis;

namespace com.xbao.tools.cache.help
{
    public class RedisHelper : IDisposable
    {

        static readonly object _lock = new object();
        static string _conf { get { return ConfigurationManager.AppSettings["Redis:Server.Cache"]; } }

        /// <summary>
        /// redis 客户端对象
        /// </summary>
        internal IRedisClient Core { get; private set; }
        /// <summary>
        /// 初始化并创建一个redis客户端
        /// </summary>
        /// <param name="db">默认缓存数据库</param>
        public RedisHelper(int db = 0)
        {
            if (this.Core == null)
            {
                lock (_lock)
                {
                    if (this.Core == null) { CreateRedis(); }
                }
            }
            this.SetDb(db);
        }
        /// <summary>
        /// 设置缓存数据库，并返回Redis客户端
        /// </summary>
        /// <param name="db">缓存数据库（默认0,3-16）</param>
        public void SetDb(int db)
        {
            if (this.Core != null)
            {
                this.Core.Db = db;
            }
        }
        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (this.Core != null)
            {
                this.Core.Dispose();
                this.Core = null;
            }
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 创建一个redis客户端
        /// </summary>
        private void CreateRedis()
        {
            string prot = "6379";
            string host = "127.0.0.1";
            string pass = "com.ehome.redis_cache";
            if (!string.IsNullOrWhiteSpace(_conf))
            {
                string server = _conf.Split('@')[0];
                string userpw = _conf.Split('@')[1];

                host = server.Split(':')[0];
                prot = server.Split(':')[1];
                pass = userpw;
            }
            this.Core = new RedisClient(host, Convert.ToInt32(prot)) { Password = pass };
        }
    }
}
