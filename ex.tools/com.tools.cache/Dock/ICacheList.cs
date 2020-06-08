using System;
using System.Collections.Generic;

namespace com.xbao.tools.cache.dock
{
    /// <summary>
    /// ICacheList ---- 集合数据缓存
    /// </summary>
    public interface ICacheList
    {
        #region 通用方法 - Add  向集合缓存中添加一个元素
        /// <summary>
        /// 向集合缓存中添加一个元素
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="value">缓存值</param>
        void Add(string listId, string value);
        /// <summary>
        /// 向集合缓存中添加一个元素
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="value">缓存值</param>
        void Add<T>(string listId, T value) where T : class;
        #endregion

        #region 通用方法 - AddRange  向集合缓存中添加多个元素
        /// <summary>
        /// 向集合缓存中添加多个元素
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="values">缓存值</param>
        void AddRange(string listId, List<string> values);
        /// <summary>
        /// 向集合缓存中添加多个元素
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="values">缓存值</param>
        void AddRange<T>(string listId, List<T> values) where T : class;
        #endregion

        #region 通用方法 - Get  获取缓存KEY的值
        /// <summary>
        /// 获取集合缓存listId的所有值
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        List<string> Get(string listId);
        /// <summary>
        /// 获取集合缓存listId的所有值
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        List<T> Get<T>(string listId) where T : class;
        #endregion        
        #region 通用方法 - Shift  从第一项删除并返回删除的项
        /// <summary>
        /// 删除集合缓存第一项并返回删除的项
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        string Shift(string listId);
        /// <summary>
        /// 删除集合缓存第一项并返回删除的项
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        T Shift<T>(string listId) where T : class;
        #endregion

        #region 通用方法 - Pop  从尾部删除一项并返回删除的项
        /// <summary>
        /// 从尾部删除一项并返回删除的项
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        string Pop(string listId);
        /// <summary>
        /// 从尾部删除一项并返回删除的项
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        T Pop<T>(string listId) where T : class;
        #endregion

        #region 通用方法 - Remove  删除缓存
        /// <summary>
        /// 清空集合缓存listId
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        void Remove(string listId);
        /// <summary>
        /// 移除集合缓存中某项值
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="value">指定缓存值</param>
        void Remove(string listId, string value);
        /// <summary>
        /// 移除集合缓存中某项值
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="value">指定缓存值</param>
        void Remove<T>(string listId, T value) where T : class;
        #endregion

        #region 通用方法 - Contains  检查缓存KEY是否存在
        /// <summary>
        /// 检查缓存KEY是否存在
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        bool Contains(string listId);
        #endregion

        #region 通用方法 - Expire 设置缓存到期时间
        /// <summary>
        /// 设置缓存的到期时间
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="mintue">延长过期时间，单位分</param>
        bool Expire(string listId, int mintue);
        /// <summary>
        /// 设置缓存到期时间
        /// </summary>
        /// <param name="listId">缓存KEY</param>
        /// <param name="expireAt">到期时间</param>
        bool Expire(string listId, DateTime expireAt);
        #endregion
    }
}
