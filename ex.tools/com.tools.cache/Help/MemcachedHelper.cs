using System;
using System.Configuration;
using System.Net;

namespace com.xbao.tools.cache.help
{
    public class MemcachedHelper : IDisposable
    {
        static readonly object _lock = new object();
        static string _conf { get { return ConfigurationManager.AppSettings["Memcached:Server.Cache"]; } }

        /// <summary>
        /// redis 客户端对象
        /// </summary>
        internal object Core { get; set; } // MemcachedClient Core { get; private set; }
        /// <summary>
        /// 初始化并创建一个Memcached客户端
        /// </summary>
        public MemcachedHelper()
        {
            if (Core == null)
            {
                lock (_lock)
                {
                    if (Core == null) { CreateMemcached(); }
                }
            }
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (this.Core != null)
            {
                // this.Core.Dispose();
                this.Core = null;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 创建一个Memcached客户端
        /// </summary>
        private void CreateMemcached()
        {
            string prot = "11211";
            string host = "127.0.0.1";
            string user = "";
            string pass = "";
            if (!string.IsNullOrWhiteSpace(_conf))
            {
                string server = _conf.Split('/')[0];
                string userpw = _conf.Split('/')[1];
                host = server.Split(':')[0];
                prot = server.Split(':')[1];
                if (!string.IsNullOrEmpty(userpw))
                {
                    user = userpw.Split('@')[0];
                    pass = userpw.Split('@')[1];
                }
            }
            /*
            MemcachedClientConfiguration memConfig = new MemcachedClientConfiguration();
            // 配置文件 - ip
            memConfig.Servers.Add(new IPEndPoint(IPAddress.Parse(host), Convert.ToInt32(prot)));
            // 配置文件 - 协议
            memConfig.Protocol = MemcachedProtocol.Binary;
            // 配置文件-权限，如果使用了免密码功能，则无需设置userName和password
            memConfig.Authentication.Type = typeof(PlainTextAuthenticator);
            memConfig.Authentication.Parameters["zone"] = "";
            if (!string.IsNullOrEmpty(user))
            {
                memConfig.Authentication.Parameters["userName"] = user;
                memConfig.Authentication.Parameters["password"] = pass;
            }
            //下面请根据实例的最大连接数进行设置
            memConfig.SocketPool.MinPoolSize = 5;
            memConfig.SocketPool.MaxPoolSize = 200;
            this.Core = new MemcachedClient(memConfig);
            */
        }
    }
}
