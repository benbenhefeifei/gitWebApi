using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using com.xbao.db.core;

namespace com.xbao.db.core
{
    public class GenericDbTable
    {
        #region 数据表 参数
        /// <summary>
        /// 获取或设置 当前数据类型
        /// </summary>
        public EDbType EType { get; set; }
        /// <summary>
        /// 获取或设置 数据表名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取数据表主键是否自增
        /// </summary>
        public bool AutoNumber { get; set; }
        /// <summary>
        /// 获取数据表主键字段
        /// </summary>
        public string PKey { get; set; }
        /// <summary>
        /// 获取数据库表字段集合
        /// </summary>
        public List<string> Fields { get; set; }
        #endregion

        #region 操作SQL语句
        /// <summary>
        /// 字段过滤
        /// </summary>
        private Regex RgxCol = new Regex(@"(\[)|(\])|(`)");
        /// <summary>
        /// 集合字段过滤
        /// </summary>
        private Regex RgxSql = new Regex(@"(?<=\])\.\w+\(\)\w+(?=\,)");
        #endregion

        /// <summary>
        /// 格式化查询条件
        /// </summary>
        /// <param name="wpargs">查询参数</param>
        /// <param name="wheres">查询条件「输出」</param>
        public IDictionary<string, object> ConvertWhere(object wpargs, ref string wheres)
        {
            IDictionary<string, object> parameter = new Dictionary<string, object>();
            if (wpargs == null) { wheres = ""; }
            else
            {
                switch (wpargs.GetType().ToString())
                {
                    case "System.String": wheres = wpargs.ToString(); break;
                    case "System.Collections.Generic.Dictionary`2[System.String,System.Object]":
                    case "System.Collections.Generic.IDictionary`2[System.String,System.Object]":
                        string tmpat = "{0}=@{1}";
                        if (EType == EDbType.MSSQL) { tmpat = "[{0}]=@{1}"; }
                        if (EType == EDbType.MYSQL) { tmpat = "`{0}`=@{1}"; }
                        parameter = (Dictionary<string, object>)wpargs;
                        wheres = string.Join(" AND ", parameter.Keys.Select(k => { return string.Format(tmpat, k, RgxCol.Replace(k, "")); }));
                        break;
                    default: wheres = ""; break;
                }
            }
            return parameter;
        }
        /// <summary>
        /// 实体模型对象转KeyValue参数
        /// </summary>
        public IDictionary<string, object> ConvertParams(EQType type, object wpargs, ref string fields, params string[] cols)
        {
            IDictionary<string, object> parameter = new Dictionary<string, object>();

            if (wpargs == null) { fields = ""; return parameter; }

            if (wpargs.GetType() == typeof(string))
            {
                fields = wpargs.ToString();
                return parameter;
            }

            switch (wpargs.GetType().ToString())
            {
                case "System.Collections.Generic.Dictionary`2[System.String,System.Object]":
                case "System.Collections.Generic.IDictionary`2[System.String,System.Object]":
                    parameter = (Dictionary<string, object>)wpargs;
                    break;
            }
            if (parameter.Count == 0 && wpargs.GetType().IsClass)
            {
                PropertyInfo[] columns = wpargs.GetType().GetProperties();
                foreach (PropertyInfo property in columns)
                {
                    Attribute col_attr = property.GetCustomAttribute(typeof(ColumnAttribute), true);
                    string colName = col_attr != null ? ((ColumnAttribute)col_attr).Name : "";
                    if (cols.Length > 0 && !cols.Contains(colName)) { continue; }
                    if (!string.IsNullOrEmpty(colName))
                    {
                        parameter.Add(colName, property.GetValue(wpargs, null));
                    }
                }
            }
            fields = ConvertFields(type, parameter.Keys.ToList());
            return parameter;
        }
        /// <summary>
        /// 格式化列字段，支持 INSERT，UPDATE，SELECT
        /// </summary>
        /// <param name="type"> 操作类型 EQType </param>
        /// <param name="wpargs">参数</param>
        public string ConvertFields(EQType type, object wpargs)
        {
            if (wpargs == null) { return ""; }

            if (wpargs.GetType() == typeof(string))
            {
                return wpargs.ToString();
            }
            List<string> fielgs = new List<string>();

            if (wpargs.GetType() == typeof(string[]))
            {
                fielgs = ((string[])wpargs).ToList();
            }
            if (wpargs.GetType() == typeof(List<string>))
            {
                fielgs = ((List<string>)wpargs);
            }
            if (wpargs.GetType() == typeof(IList<string>))
            {
                fielgs = ((IList<string>)wpargs).ToList();
            }

            if (type == EQType.UPDATE)
            {
                string tmpat = "{0}=@{1}";
                if (EType == EDbType.MSSQL) { tmpat = "[{0}]=@{1}"; }
                if (EType == EDbType.MYSQL) { tmpat = "`{0}`=@{1}"; }
                return string.Join(",", fielgs.Select(field => string.Format(tmpat, field, RgxCol.Replace(field, ""))));
            }
            else
            {
                if (EType == EDbType.MSSQL) { return "[" + string.Join("],[", fielgs) + "]"; }
                if (EType == EDbType.MYSQL) { return "`" + string.Join("`,`", fielgs) + "`"; }
                return string.Join(",", fielgs);
            }            
        }
    }
}
