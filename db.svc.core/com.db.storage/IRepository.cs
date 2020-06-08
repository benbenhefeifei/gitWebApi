using System;
using System.Collections.Generic;

namespace com.xbao.db.storage
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : core.IDbHelper, IDisposable where T : class
    {
        #region 数据表 参数
        /// <summary>
        /// 获取或设置 数据表名
        /// </summary>
        public core.GenericDbTable DbTable { get; set; }
        #endregion

        /// <summary>
        /// 向数据表中插入一条数据
        /// </summary>
        /// <param name="t">数据源</param>
        /// <returns>成功:源主键变化，失败:源主键不变</returns>
        long Insert(T t);
        /// <summary>
        /// 向数据表中批量插入多条数据
        /// </summary>
        /// <param name="ts">数据源</param>
        bool Inserts(IEnumerable<T> ts);

        /// <summary>
        /// 提交并修改数据表中一条记录
        /// 支持部分修改
        /// </summary>
        /// <param name="t">数据源</param>
        /// <param name="cols">更新部分列</param>
        /// <returns>成功:返回变化后的数据对象，失败:返回变化前的数据对象</returns>
        T Update(T t, params string[] cols);
        /// <summary>
        /// 提交并修改数据表中一条或多条记录
        /// </summary>
        /// <param name="cloumns">要更新的字段</param>
        /// <param name="wheres">更新条件</param>
        bool Updates(object cloumns, object wheres);

        /// <summary>
        /// 移除一条或多条相符的数据记录
        /// </summary>
        /// <param name="wheres">删除条件</param>
        bool Remove(object wheres);

        /// <summary>
        /// 根据表达式过滤筛选，获取多条相符的数据记录数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        long Count(object wheres);
        /// <summary>
        /// 根据表达式过滤筛选，获取第一条相符的数据记录，并转换为相对于的实体
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <param name="fields">查询字段</param>
        /// <param name="orderby">查询排序</param>
        T Find(object wheres, string fields = "*", string orderby = "");
        /// <summary>
        /// 根据表达式过滤筛选，获取多条相符的数据记录，并转换为相对于的实体集合（支持分页）
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <param name="fields">查询字段</param>
        /// <param name="orderby">查询排序</param>
        /// <param name="page">数据分页页码</param>
        /// <param name="limit">数据分页行数</param>
        IEnumerable<T> Filter(object wheres, string fields = "*", string orderby = "", int page = 1, int limit = 20);
    }
}
