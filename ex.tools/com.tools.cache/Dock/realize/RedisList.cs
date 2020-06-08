using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace com.xbao.tools.cache.dock
{
    internal class RedisList : help.RedisHelper, ICacheList
    {
        public RedisList(int db = 1) : base(db)
        {
        }

        #region 通用方法 - Add  向集合缓存中添加一个元素
        /// <summary>
        /// 向集合缓存中添加一个元素
        /// </summary>
        public void Add(string listId, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { return; }

            using (IRedisClient redis = base.Core)
            {
                redis.AddItemToList(listId.Prefix(), value);
            }
        }
        /// <summary>
        /// 向集合缓存中添加一个元素
        /// </summary>
        public void Add<T>(string listId, T model) where T : class
        {
            if (model == null) { return; }

            using (IRedisClient redis = base.Core)
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString(model);
                redis.AddItemToList(listId.Prefix(), value);
                //IRedisTypedClient<T> redisClient = redis.As<T>();
                //redisClient.AddItemToList(redisClient.Lists[listId.Prefix()], model);
            }
        }
        #endregion
        #region 通用方法 - AddRange  向集合缓存中添加多个元素
        /// <summary>
        /// 向集合缓存中添加多个元素
        /// </summary>
        public void AddRange(string listId, List<string> values)
        {
            if (values != null && values.Count > 0)
            {
                using (IRedisClient redis = base.Core)
                {
                    redis.AddRangeToList(listId.Prefix(), values);
                }
            }
        }
        /// <summary>
        /// 向集合缓存中添加多个元素
        /// </summary>
        public void AddRange<T>(string listId, List<T> values) where T : class
        {
            if (values != null && values.Count > 0)
            {
                using (IRedisClient redis = base.Core)
                {
                    List<string> myList = values.Select(model => ServiceStack.Text.JsonSerializer.SerializeToString(model)).ToList();
                    redis.AddRangeToList(listId.Prefix(), myList);
                }
            }
        }
        #endregion
        #region 通用方法 - Get  获取缓存KEY的值
        /// <summary>
        /// 获取集合缓存listId的所有值
        /// </summary>
        public List<string> Get(string listId)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.GetAllItemsFromList(listId.Prefix());
            }
        }
        /// <summary>
        /// 获取集合缓存listId的所有值
        /// </summary>
        public List<T> Get<T>(string listId) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                List<string> jsonStr = redis.GetAllItemsFromList(listId.Prefix());
                IEnumerable<T> result = jsonStr.Select(str => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str.Trim("\"".ToCharArray())));
                return result.ToList();
                //IRedisTypedClient<T> redisClient = redis.As<T>();
                //return redisClient.GetAllItemsFromList(redisClient.Lists[listId.Prefix()]);
            }
        }
        #endregion        
        #region 通用方法 - Shift  从第一项删除并返回删除的项
        /// <summary>
        /// 删除集合缓存第一项并返回删除的项
        /// </summary>
        public string Shift(string listId)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.RemoveStartFromList(listId.Prefix());
            }
        }
        /// <summary>
        /// 删除集合缓存第一项并返回删除的项
        /// </summary>
        public T Shift<T>(string listId) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                IRedisTypedClient<T> redisClient = redis.As<T>();
                return redisClient.RemoveStartFromList(redisClient.Lists[listId.Prefix()]);
            }
        }
        #endregion
        #region 通用方法 - Pop  从尾部删除一项并返回删除的项
        /// <summary>
        /// 从尾部删除一项并返回删除的项
        /// </summary>
        public string Pop(string listId)
        {
            using (IRedisClient redis = base.Core)
            {
                return redis.PopItemFromList(listId.Prefix());
            }
        }
        /// <summary>
        /// 从尾部删除一项并返回删除的项
        /// </summary>
        public T Pop<T>(string listId) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                IRedisTypedClient<T> redisClient = redis.As<T>();
                return redisClient.PopItemFromList(redisClient.Lists[listId.Prefix()]);
            }
        }
        #endregion
        #region 通用方法 - Remove  删除缓存
        /// <summary>
        /// 清空集合缓存listId
        /// </summary>
        public void Remove(string listId)
        {
            using (IRedisClient redis = base.Core)
            {
                redis.RemoveAllFromList(listId.Prefix());
            }
        }
        public void Remove(string listId, string value)
        {
            using (IRedisClient redis = base.Core)
            {
                redis.RemoveItemFromList(listId.Prefix(), value);
            }
        }
        public void Remove<T>(string listId, T model) where T : class
        {
            using (IRedisClient redis = base.Core)
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString(model);
                redis.RemoveItemFromList(listId.Prefix(), value);
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
