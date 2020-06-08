using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.xbao.db.storage
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : core.GenericDbHelper , IRepository<T> where T : class
    {
        /// <summary>
        /// 数据表信息
        /// </summary>
        public core.GenericDbTable DbTable { get; set; }

        #region 实现父类 GenericDbHelper 的对象实例
        /// <summary>
        /// 初始化数据仓储
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        public GenericRepository(string dbName) : base(dbName)
        {
            this.DbTable = new core.GenericDbTable();
            this.DbTable.EType = core.EDbType.MYSQL;
        }
        #endregion

        #region 实现接口 IRepository<T> 获取 --- Reader 读操作
        /// <summary>
        /// 根据表达式过滤筛选，获取多条相符的数据记录数
        /// </summary>
        /// <param name="wparams">数据源参数</param>
        public virtual long Count(object wparams)
        {
            string wheres = string.Empty;

            IDictionary<string, object> parameter = DbTable.ConvertWhere(wparams, ref wheres);

            if (!string.IsNullOrEmpty(wheres)) { wheres = "WHERE " + wheres; }

            string select = string.Format("SELECT COUNT(1) AS TCOUNT FROM {0} {1}", DbTable.Name, wheres);

            return Reader.Count(select, parameter);
        }
        /// <summary>
        /// 根据表达式过滤筛选，获取第一条相符的数据记录，并转换为相对于的实体
        /// </summary>
        /// <param name="wparams">查询条件</param>
        /// <param name="fields">查询字段</param>
        /// <param name="orderby">查询排序</param>
        public virtual T Find(object wparams, string fields = "*", string orderby = "")
        {
            string wheres = string.Empty;

            IDictionary<string, object> parameter = DbTable.ConvertWhere(wparams, ref wheres);

            string selectTp = "SELECT {0} FROM {1} {2} ORDER BY {3}";
            if (DbTable.EType == core.EDbType.MSSQL)
            {
                selectTp = "SELECT TOP 1 {0} FROM {1} {2} ORDER BY {3}";
            }
            if (DbTable.EType == core.EDbType.MYSQL)
            {
                selectTp = "SELECT {0} FROM {1} {2} ORDER BY {3} LIMIT 1";
            }

            if (string.IsNullOrEmpty(orderby)) { orderby = DbTable.PKey + " DESC"; }

            if (!string.IsNullOrEmpty(wheres)) { wheres = "WHERE " + wheres; }

            string select = string.Format(selectTp, fields, DbTable.Name, wheres, orderby);

            T model = Reader.Find<T>(select, parameter);

            return model;
        }
        /// <summary>
        /// 根据表达式过滤筛选，获取多条相符的数据记录，并转换为相对于的实体集合
        /// </summary>
        /// <param name="wparams">查询条件</param>
        /// <param name="fields">查询字段</param>
        /// <param name="orderby">查询排序</param>
        /// <param name="page">数据分页页码</param>
        /// <param name="limit">数据分页行数</param>
        public virtual IEnumerable<T> Filter(object wparams, string fields = "*", string orderby = "", int page = 1, int limit = 20)
        {
            string wheres = string.Empty;

            IDictionary<string, object> parameter = DbTable.ConvertWhere(wparams, ref wheres);

            string filterPg = "";
            if (page > 0 && limit <= 0) { limit = 20; }
            if (DbTable.EType == core.EDbType.MSSQL && page > 0 && limit > 0)
            {
                filterPg = string.Format(" OFFSET {0} ROW FETCH NEXT {1} ROWS ONLY", (page - 1) * limit, limit);
            }
            if (DbTable.EType == core.EDbType.MYSQL && page > 0 && limit > 0)
            {
                filterPg = string.Format(" LIMIT {1} OFFSET {0}", (page - 1) * limit, limit);
            }

            if (string.IsNullOrEmpty(orderby)) { orderby = DbTable.PKey + " DESC"; }

            if (!string.IsNullOrEmpty(wheres)) { wheres = "WHERE " + wheres; }

            string select = string.Format("SELECT {0} FROM {1} {2} ORDER BY {3}" + filterPg, fields, DbTable.Name, wheres, orderby);

            return Reader.Filter<T>(select, parameter);
        }
        #endregion

        #region 实现接口 IRepository<T> 增加 --- Writer 写操作
        /// <summary>
        /// 向数据表中插入一条数据
        /// </summary>
        /// <param name="t">数据源</param>
        /// <returns>成功:主键变化，失败:主键不变</returns>
        public virtual long Insert(T t)
        {
            string fields = string.Empty;

            IDictionary<string, object> parameter = DbTable.ConvertParams(core.EQType.INSERT, t, ref fields);

            string fieldAt = string.Join(",", parameter.Keys.Select(filed => "@" + filed));

            string insert = string.Format("INSERT INTO {0}({1}) VALUES ({2})", DbTable.Name, fields, fieldAt);

            object modelId = Writer.ExecuteScalar(insert, parameter);

            return Convert.ToInt64(modelId);
        }
        /// <summary>
        /// 向数据表中批量插入多条数据
        /// </summary>
        /// <param name="ts">数据源</param>
        public virtual bool Inserts(IEnumerable<T> ts)
        {
            DataTable table = new DataTable();
            IDictionary<string, string> colkeys = new Dictionary<string, string>();
            PropertyInfo[] columns = typeof(T).GetProperties();
            foreach (PropertyInfo property in columns)
            {
                Attribute col_attr = property.GetCustomAttribute(typeof(ColumnAttribute), true);
                string colName = col_attr != null ? ((ColumnAttribute)col_attr).Name : "";
                if (!string.IsNullOrEmpty(colName))
                {
                    colkeys.Add(property.Name, colName);
                    table.Columns.Add(new DataColumn(colName));
                }
            }

            foreach (T item in ts)
            {
                DataRow newRow = table.NewRow();
                foreach (PropertyInfo property in columns)
                {
                    if (colkeys.Keys.Contains(property.Name))
                    {
                        string cname = colkeys[property.Name];
                        object value = property.GetValue(item, null);
                        if (value != null) { newRow[cname] = value; }
                    }
                }
                table.Rows.Add(newRow);
            }

            return Writer.BulkCopy(table, this.DbTable.Name);
        }
        #endregion

        #region 实现接口 IRepository<T> 移除 --- Writer 写操作
        /// <summary>
        /// 移除一条或多条相符的数据记录
        /// </summary>
        /// <param name="wparams">删除条件</param>
        public virtual bool Remove(object wparams)
        {
            string wheres = string.Empty;

            IDictionary<string, object> parameter = DbTable.ConvertWhere(wparams, ref wheres);

            string delete = string.Format("DELETE FROM {0} WHERE {1}", DbTable.Name, wheres);

            int count = Writer.ExecuteNonQuery(delete, parameter);

            return count > 0;
        }
        #endregion

        #region 实现接口 IRepository<T> 更新 --- Writer 写操作
        /// <summary>
        /// 提交并修改数据表中一条记录
        /// </summary>
        /// <param name="t">数据源</param>
        /// <param name="cols">更新部分列</param>
        /// <returns>成功:返回变化后的数据对象，失败:返回变化前的数据对象</returns>
        public virtual T Update(T t, params string[] cols)
        {
            if (cols == null) { cols = new List<string>().ToArray(); }

            string fields = string.Empty;

            string wheres = this.DbTable.PKey + "=@" + this.DbTable.PKey;

            IDictionary<string, object> parameter = DbTable.ConvertParams(core.EQType.UPDATE, t, ref fields, cols);

            string update = string.Format("UPDATE {0} SET {1} WHERE {2}", DbTable.Name, fields, wheres);

            Writer.ExecuteNonQuery(update, parameter);

            return t;
        }
        /// <summary>
        /// 提交并修改数据表中一条或多条记录
        /// </summary>
        /// <param name="cloumns">要修改的字段及新值，格式：new{field:valy]ue, ....}</param>
        /// <param name="wparams">执行条件，参考model.Query* </param>
        /// <returns>tue更新成功，反之失败</returns>
        public virtual bool Updates(object cloumns, object wparams)
        {
            string wheres = string.Empty;
            IDictionary<string, object> bparameter = DbTable.ConvertWhere(wparams, ref wheres);

            string fields = string.Empty;
            IDictionary<string, object> aparameter = DbTable.ConvertParams(core.EQType.UPDATE, cloumns, ref fields);

            string update = string.Format("UPDATE {0} SET {1} WHERE {2}", DbTable.Name, fields, wheres);

            int count = Writer.ExecuteNonQuery(update, aparameter.Concat(bparameter).ToList());

            return count > 0;
        }
        #endregion

    }
}
