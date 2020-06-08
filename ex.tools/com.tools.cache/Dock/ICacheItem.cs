using System;
namespace com.xbao.tools.cache.dock
{
    /// <summary>
    /// ICacheItem ---- 单项数据缓存
    /// </summary>
    public interface ICacheItem
    {
        #region 通用方法 - Set 若KEY已存在则修改，反之添加
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        bool Set(string key, string value);
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="minute">缓存存活时间，单位分钟</param>
        bool Set(string key, string value, int minute);
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">缓存存活截止时间</param>
        bool Set(string key, string value, DateTime expiresAt);
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        bool Set<T>(string key, T value) where T : class;
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="minute">缓存存活时间，单位分钟</param>
        bool Set<T>(string key, T value, int minute) where T : class;
        /// <summary>
        /// 向缓存中添加一条记录，若KEY已存在则修改，反之添加
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">缓存存活截止时间</param>
        bool Set<T>(string key, T value, DateTime expiresAt) where T : class;
        #endregion

        #region 通用方法 - Get 从缓存中读取一条记录
        /// <summary>
        /// 从缓存中读取一条记录
        /// </summary>
        string Get(string key);
        /// <summary>
        /// 从缓存中读取一条记录，并转换为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        #endregion

        #region 通用方法 - Remove 从缓存中移除一条或多条记录
        /// <summary>
        /// 从缓存中移除一条或多条记录
        /// </summary>
        /// <param name="keys">一个或多个缓存键KEY</param>
        void Remove(params string[] keys);
        #endregion

        #region 通用方法 - Contains  检查缓存KEY是否存在
        /// <summary>
        /// 检查缓存KEY是否存在
        /// </summary>
        bool Contains(string key);
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
