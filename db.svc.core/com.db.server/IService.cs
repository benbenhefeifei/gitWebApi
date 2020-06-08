using System;
using System.Collections.Generic;

namespace com.xbao.db.server
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> : IDisposable where T : class
    {
        /// <summary>
        /// Insert => 新增一条数据 并 返回被新增后的数据
        /// </summary>
        /// <param name="t">（必填）新增数据对象</param>
        T Insert(T t);

        /// <summary>
        /// Update => 修改一条数据 并 返回被修改后的数据
        /// </summary>
        /// <param name="t">修改目标数据对象</param>
        T Update(T t);
        /// <summary>
        /// Update => 字段修改 并返回修改结果（true成功false失败）
        /// </summary>
        /// <param name="fields">（必填）修改字段，可为字符串a=1,b=2 或 JSON格式{a=1,b=2}</param>
        /// <param name="wheres">（选填）条件字段，可为字符串a=1 AND b=2 或 JSON格式{a=1,b=2}</param>
        bool Update(object fields, object wheres);
        /// <summary>
        /// Update => 字段修改 并返回修改结果（true成功false失败）
        /// </summary>
        /// <param name="id">（必填）更新条件值</param>
        /// <param name="key">（必填）更新字段名</param>
        /// <param name="value">（必填）更新字段值</param>
        bool Update(object id, string key, object value);

        /// <summary>
        /// Remove => 逻辑删除一条符合条件的数据
        /// </summary>
        /// <param name="id">（必填）数据主键ID</param>
        bool Remove(long id);
        /// <summary>
        /// Remove => 逻辑删除一条或多条符合条件的数据
        /// </summary>
        /// <param name="wheres">（必填）筛选条件，可为字符串a=1 AND b=2 或 JSON格式{a=1,b=2}</param>
        bool Remove(object wheres);

        /// <summary>
        /// Contains => 验证数据是否已经存在
        /// </summary>
        /// <param name="wheres">（必填）筛选条件，可为字符串a=1 AND b=2 或 JSON格式{a=1,b=2}</param>
        /// <returns>验证结果（true存在，false不存在）</returns>
        bool Contains(object wheres);

        /// <summary>
        /// Find => 获取第一条符合条件的数据
        /// </summary>
        /// <param name="id">数据主键ID</param>
        T Find(long id);
        /// <summary>
        /// Delete => 获取第一条符合条件的数据
        /// </summary>
        /// <param name="wheres">（必填）筛选条件，可为字符串a=1 AND b=2 或 JSON格式{a=1,b=2}</param>
        T Find(object wheres);

        /// <summary>
        /// Filter => 获取所有符合条件的数据，支持分页查询
        /// </summary>
        /// <param name="wheres">（必填）筛选条件，可为字符串a=1 AND b=2 或 JSON格式{a=1,b=2}</param>
        /// <param name="orderby">（选填）排序字段方式</param>
        /// <param name="page">（选填）分页页码，大于0有效</param>
        /// <param name="limit">（选填）获取行数，大于0有效</param>
        IEnumerable<T> Filter(object wheres = null, string orderby = "", int page = 1, int limit = 20);
    }
}
