using System;
using System.Collections.Generic;

namespace com.xbao.tools.cache.dock
{
    /// <summary>
    /// ICacheHash ---- 哈希数据缓存
    /// </summary>
    public interface ICacheHash
    {
        #region 通用方法 - Set  设置一个Hash缓存值
        /// <summary>
        /// 设置Hash缓存，添加或修改一个键值，如果哈希缓存的key存在则覆盖
        /// </summary>
        /// <param name="hashId">哈希key</param>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        bool Set(string hashId, string key, object value);
        #endregion

        #region 通用方法 - SetRange  设置一个或多个Hash缓存值
        /// <summary>
        /// 设置Hash缓存，添加或修改一个或多个键值，如果哈希缓存的key存在则覆盖
        /// </summary>
        void SetRange(string hashId, IDictionary<string, object> keyValuePairs);
        #endregion

        #region 通用方法 - GetValue  获取缓存值
        /// <summary>
        /// 根据HashId获取该HashId下的所有值
        /// </summary>
        List<T> GetValues<T>(string hashId);
        /// <summary>
        /// 获取哈希缓存的 HashId - key值
        /// </summary>
        T GetValue<T>(string hashId, string key);
        #endregion

        #region 通用方法 - Remove  删除缓存
        /// <summary>
        /// 清空指定哈希缓存hashId
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        bool Remove(string hashId);
        /// <summary>
        /// 移除哈希缓存子元素
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        /// <param name="key">缓存子元素KEY</param>
        bool Remove(string hashId, string key);
        #endregion

        #region 通用方法 - Contains  检查缓存是否存在
        /// <summary>
        /// 检查缓存HashID是否存在
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        bool Contains(string hashId);
        /// <summary>
        /// 检查哈希缓存子元素是否存在
        /// </summary>
        /// <param name="hashId">缓存HashID</param>
        /// <param name="key">缓存子元素KEY</param>
        bool Contains(string hashId, string key);
        #endregion

        #region 通用方法 - Expire 设置缓存到期时间
        /// <summary>
        /// 设置缓存的到期时间
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="mintue">延长过期时间，单位分</param>
        /// <returns></returns>
        bool Expire(string key, int mintue);
        /// <summary>
        /// 设置缓存到期时间
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="expireAt">到期时间</param>
        /// <returns></returns>
        bool Expire(string key, DateTime expireAt);
        #endregion
    }
}
