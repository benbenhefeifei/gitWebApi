using System;
using System.Linq;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace com.xbao.tools.cache.dock
{
    internal class RedisItem : help.RedisHelper, ICacheItem
    {
        public RedisItem(int db = 0) : base(db)
        {
        }

        #region 通用方法 - Set 若KEY已存在则修改，反之添加
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        public bool Set(string key, string value)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.Set(key.Prefix(), value);
            }
        }
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="minute">缓存存活时间，单位分钟</param>
        public bool Set(string key, string value, int minute)
        {
            return Set(key, value, DateTime.Now.AddMinutes(minute));
        }
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">缓存存活截止时间</param>
        public bool Set(string key, string value, DateTime expiresAt)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.Set(key.Prefix(), value, DateTime.Now.AddMinutes(10));
            }
        }

        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        public bool Set<T>(string key, T value) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.Set(key.Prefix(), value);
            }
        }
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="minute">缓存存活时间，单位分钟</param>
        public bool Set<T>(string key, T value, int minute) where T : class
        {
            return Set(key, value, DateTime.Now.AddMinutes(minute));
        }
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">缓存存活截止时间</param>
        public bool Set<T>(string key, T value, DateTime expiresAt) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.Set(key.Prefix(), value, expiresAt);
            }
        }
        #endregion
        #region 通用方法 - Get 从缓存中读取一条记录
        /// <summary>
        /// 从缓存中读取一条记录
        /// </summary>
        public string Get(string key)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.GetValue(key.Prefix());
            }
        }
        /// <summary>
        /// 从缓存中读取一条记录，并转换为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                string jsonStr = redis.GetValue(key.Prefix());
                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    T result = JsonConvert.DeserializeObject<T>(jsonStr.Trim("\"".ToCharArray()));
                    return result;
                }
                return default(T);
            }
        }
        #endregion
        #region 通用方法 - Remove 从缓存中移除一条或多条记录
        /// <summary>
        /// 从缓存中移除一条或多条记录
        /// </summary>
        /// <param name="keys">一个或多个缓存键KEY</param>
        public void Remove(params string[] keys)
        {
            if (keys != null && keys.Length > 0)
            {
                using (IRedisClient redis = base.Core)
                {
                    redis.RemoveAll(keys.ToList().Prefix());
                }
            }
        }
        #endregion
        #region 通用方法 - Contains  检查缓存KEY是否存在
        /// <summary>
        /// 检查缓存KEY是否存在
        /// </summary>
        public bool Contains(string key)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.ContainsKey(key.Prefix());
            }
        }
        #endregion
        #region 通用方法 - Expire 设置缓存到期时间
        /// <summary>
        /// 设置缓存到期时间
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="expireAt">到期时间</param>
        /// <returns></returns>
        public bool Expire(string key, DateTime expireAt)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.ExpireEntryAt(key.Prefix(), expireAt);
            }
        }
        /// <summary>
        /// 设置缓存的到期时间
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="mintue">延长过期时间，单位分</param>
        /// <returns></returns>
        public bool Expire(string key, int mintue)
        {
            return Expire(key, DateTime.Now.AddMinutes(mintue));
        }
        #endregion
    }
}
