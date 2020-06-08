

namespace System
{
    using Reflection;
    using ComponentModel;
    using Collections.Generic;
    using Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations.Schema;

    public static class QueryExtensions
    {
        /// <summary>
        /// [自定义扩展] 获取对象属性元素 Column自定义扩展字段名称
        /// </summary>
        public static string GetTableColumnName(this PropertyInfo property)
        {
            Attribute attribute = property.GetCustomAttribute(typeof(ColumnAttribute), true);

            if (attribute != null)
            {
                return ((ColumnAttribute)attribute).Name;
            }
            return string.Empty;
        }

        /// <summary>
        /// [自定义扩展] 将此实例属性字段的自定义特性转化为SQL可执行命令条件
        /// </summary>
        /// <param name="source">查询实例对象</param>
        /// <returns>返回SQL可执行命令条件</returns>
        public static string GetSqlCmdWheres<T>(this T source)
        {
            List<string> query = new List<string>();
            if (source != null)
            {
                char[] splits = new char[] { ' ', '　', ',', '，', ';', '；', '|', '-', '~' };
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    Type type = property.PropertyType;
                    string spacr = "=";
                    string field = property.Name;
                    string value = (property.GetValue(source, null) ?? "").ToString().SqlFilters(@"(-999)|(\[)|(\])");

                    if (!string.IsNullOrEmpty(value))
                    {
                        Attribute attributes = property.GetCustomAttribute(typeof(QueryFieldAttribute));
                        if (attributes != null)
                        {
                            QueryFieldAttribute column = (QueryFieldAttribute)attributes;
                            if (column.Type != null) { type = column.Type; }
                            if (!string.IsNullOrEmpty(column.Name)) { field = column.Name; }
                            if (!string.IsNullOrEmpty(column.Spacer)) { spacr = column.Spacer; }

                            #region like | not like
                            if (spacr.Contains("like"))
                            {
                                query.Add(string.Format("{0} {1} '%[{2}]%'", field, spacr, string.Join(",", value.Split(splits))));
                            }
                            #endregion
                            #region in | not in
                            else if (spacr.Contains("in"))
                            {
                                string fmtat = "{0} {1} ({2})";
                                if (type == typeof(string) || type == typeof(DateTime) || type == typeof(DateTime?))
                                {
                                    fmtat = "{0} {1} ('{2}')";
                                }
                                query.Add(string.Format(fmtat, field, spacr, string.Join(",", value.Split(splits))));
                            }
                            #endregion
                            #region between and 若起止任意值为空，则转换为 >=|<= 
                            else if (spacr.Contains("between"))
                            {
                                string[] values = (new Regex(@"(,)|(，)|(;)|(；)|(~)|(_)")).Replace(value, "|").Split('|');
                                string endVal = "";
                                string begVal = values[0].Trim();
                                if (values.Length > 1) { endVal = values[1].Trim(); }

                                if (type == typeof(DateTime) || type == typeof(DateTime?))
                                {
                                    if (begVal.Length == 10) { begVal = begVal + " 00:00:01"; }
                                    if (endVal.Length == 10) { endVal = endVal + " 23:59:59"; }
                                }
                                if (!string.IsNullOrEmpty(begVal) && !string.IsNullOrEmpty(endVal))
                                {
                                    query.Add(string.Format("{0} between '{1}' and '{2}'", field, begVal, endVal));
                                }
                                else if (!string.IsNullOrEmpty(begVal))
                                {
                                    query.Add(string.Format("{0} >= @{1}", field, begVal));
                                }
                                else if (!string.IsNullOrEmpty(endVal))
                                {
                                    query.Add(string.Format("{0} <= @{1}", field, endVal));
                                }
                            }
                            #endregion
                            #region =|<>|>|<|<=|>=
                            else
                            {
                                query.Add(string.Format("{0} {1} '{2}'", field, spacr, value));
                            }
                            #endregion
                        }
                    }
                }

            }
            return string.Join(" AND ", query);
        }
    }
}

namespace System.ComponentModel
{
    /// <summary>
     /// 【自定义】属性字段查询特性扩展
     /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class QueryFieldAttribute : Attribute
    {
        public QueryFieldAttribute()
        {
        }
        /// <summary>
        /// 自定义查询特性
        /// </summary>
        /// <param name="join">条件链接（and|or）</param>
        /// <param name="name">条件字段名</param>
        /// <param name="type">类型</param>
        /// <param name="spacer">操作符,默认=</param>
        /// <param name="size">数据长度,默认0</param>
        public QueryFieldAttribute(string join, string name, Type type, string spacer = "=", int size = 0)
        {
            this.Type = type;
            this.Name = name;
            this.Size = size;
            this.Spacer = spacer;
        }
        /// <summary>
        /// 字段类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 数据长度
        /// 默认为0
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 与上一个操作链接 （and|or）
        /// </summary>
        public string Join { get; set; }
        /// <summary>
        /// 操作符（in|not|like|between =|<>|>|<|>=|<=）
        /// 为空时默认为=
        /// </summary>
        public string Spacer { get; set; }
    }
}
