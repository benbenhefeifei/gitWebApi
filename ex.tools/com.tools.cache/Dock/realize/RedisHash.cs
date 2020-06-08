using System;
using System.Collections.Generic;
using ServiceStack.Redis;

namespace com.xbao.tools.cache.dock
{
    internal class RedisHash : help.RedisHelper, ICacheHash
    {
        public RedisHash(int db = 2) : base(db)
        {
        }

        #region 通用方法 - Set  设置一个Hash缓存值
        /// <summary>
        /// 设置Hash缓存，添加或修改一个键值，如果哈希缓存的key存在则覆盖
        /// </summary>
        /// <param name="hashId">哈希key</param>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        public bool Set(string hashId, string key, object value)
        {
            if (!string.IsNullOrEmpty(key) && value != null)
            {
                // Newtonsoft.Json.JsonConvert.SerializeObject(value);
                if (value.GetType().IsAnsiClass) { value = ServiceStack.Text.JsonSerializer.SerializeToString(value); }
                
                using (IRedisClient redis = base.Core)
                {
                    return redis.SetEntryInHash(hashId.Prefix(), key, value.ToString());
                }
            }
            return false;
        }
        #endregion
        #region 通用方法 - SetRange  设置一个或多个Hash缓存值
        /// <summary>
        /// 设置Hash缓存，添加或修改一个或多个键值，如果哈希缓存的key存在则覆盖
        /// </summary>
        public void SetRange(string hashId, IDictionary<string, object> keyValuePairs)
        {
            if (keyValuePairs != null && keyValuePairs.Count > 0)
            {
                IDictionary<string, string> myList = new Dictionary<string, string>();
                foreach (var model in keyValuePairs)
                {
                    // Newtonsoft.Json.JsonConvert.SerializeObject(value);
                    string value = model.Value.GetType().IsAnsiClass ?
                        ServiceStack.Text.JsonSerializer.SerializeToString(model.Value) :
                        model.Value.ToString();

                    myList.Add(model.Key, value);
                }
                using (IRedisClient redis = base.Core)
                {
                    redis.SetRangeInHash(hashId.Prefix(), myList);
                }
            }
        }
        #endregion
        #region 通用方法 - GetValue  获取缓存值
        /// <summary>
        /// 获取哈希缓存的 HashId - key值
        /// </summary>
        public T GetValue<T>(string hashId, string key)
        {
            using (IRedisClient redis = base.Core)
            {
                string item = redis.GetValueFromHash(hashId.Prefix(), key);
                if (!string.IsNullOrWhiteSpace(item))
                {
                    T value = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                    // T value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(item.Trim("\"".ToCharArray()));
                    return value;
                }
                return default(T);
            }
        }
        #endregion
        #region 通用方法 - GetValues  获取缓存值集合
        /// <summary>
        /// 根据HashId获取该HashId下的所有值
        /// </summary>
        public List<T> GetValues<T>(string hashId)
        {
            using (IRedisClient redis = base.Core)
            {
                List<T> result = new List<T>();
                foreach (string item in redis.GetHashValues(hashId.Prefix()))
                {
                    T value = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                    // T value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(item.Trim("\"".ToCharArray()));
                    result.Add(value);
                }
                return result;
            }
        }
        #endregion        
        #region 通用方法 - Remove  删除缓存
        /// <summary>
        /// 清空指定哈希缓存hashId
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        public bool Remove(string hashId)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.Remove(hashId.Prefix());
            }
        }
        /// <summary>
        /// 移除哈希缓存子元素
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        /// <param name="key">缓存子元素KEY</param>
        public bool Remove(string hashId, string key)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.RemoveEntryFromHash(hashId.Prefix(), key);
            }
        }
        #endregion
        #region 通用方法 - Contains  检查缓存是否存在
        /// <summary>
        /// 检查缓存HashID是否存在
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        public bool Contains(string hashId)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.ContainsKey(hashId.Prefix());
            }
        }
        /// <summary>
        /// 检查哈希缓存子元素是否存在
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        /// <param name="key">缓存子元素KEY</param>
        public bool Contains(string hashId, string key)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.HashContainsEntry(hashId.Prefix(), key);
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
