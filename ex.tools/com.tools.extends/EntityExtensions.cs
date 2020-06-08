namespace System
{
    using Data;
    using Linq;
    using Reflection;
    using ComponentModel;
    using Collections.Generic;

    /// <summary>
    /// 对象属性元素扩展 （扩展）
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// [自定义扩展] 获取对象指定字段属性值
        /// </summary>
        public static string GetValueByProp<T>(this T that, string key) where T : class
        {
            PropertyInfo property = typeof(T).GetProperty(key);
            if (property != null)
            {
                object value = property.GetValue(that, null);
                return (value ?? "").ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// [自定义扩展] 设置对象指定字段属性值
        /// </summary>
        public static T SetValueByProp<T>(this T that, string key, object value) where T : class
        {
            PropertyInfo property = typeof(T).GetProperty(key);
            if (property != null) { property.SetValue(that, value); }
            return that;
        }

        /// <summary>
        /// [自定义扩展] 获取此实例的属性值并写入字典返回
        /// </summary>
        /// <param name="entity">要获取属性的对象</param>
        /// <param name="fields">要获取的字段，为空时获取整个对象</param>
        public static IDictionary<string, object> GetProperties<T>(this T entity, bool tableCol = false, params string[] fields) where T : class
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            if (entity == null) { return properties; }

            if (fields == null) { fields = new string[] { }; }
            fields = fields.Select(s => s.ToLower()).ToArray();

            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                string name = property.Name;
                if (tableCol) { name = property.GetTableColumnName(); }
                if (!property.CanWrite) { continue; }
                if (fields.Length > 0 && !fields.Contains(name.ToLower())) { continue; }
                properties.Add(name, property.GetValue(entity, null));
            }

            return properties;
        }
        /// <summary>
        /// [自定义扩展] 将此实例的属性值 按指定的属性值 重新设置
        /// </summary>
        /// <param name="entity">要设置的对象</param>
        /// <param name="fields">新的属性值字典</param>
        /// <param name="setNull">NULL值是否设置</param>
        public static T SetProperties<T>(this T entity, IDictionary<string, object> fields, bool tableCol = false, bool setNull = true) where T : class
        {
            if (entity == null) { return entity; }
            if (!(fields != null && fields.Count > 0)) { return entity; }

            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                string name = property.Name;
                if (tableCol) { name = property.GetTableColumnName(); }
                if (!property.CanWrite) { continue; }
                if (!fields.Keys.Select(s => s.ToLower()).Contains(name.ToLower())) { continue; }
                object value = fields.GetValue(name).ToObject(property.PropertyType);
                property.SetValue(entity, value, null);
            }

            return entity;
        }

        /// <summary>
        /// [自定义扩展] 将此实例的属性值复制至目标实例
        /// </summary>
        /// <param name="source">源对象</param>
        /// <param name="target">目标对象</param>
        /// <param name="fields">要复制的字段，为空复制全部</param>
        public static void CopyTo<T>(this T source, T target, params string[] fields) where T : class
        {
            if (fields == null) { fields = new string[] { }; }
            fields = string.Join(",", fields).ToLower().Split(',');

            if (source != null && target != null)
            {
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    if (!property.CanWrite) { continue; }
                    if (fields.Length > 0 && !fields.Contains(property.Name.ToLower())) { continue; }

                    property.SetValue(target, property.GetValue(source, null), null);
                }
            }
        }

        /// <summary>
        /// 对比两个实体并返回需要更新的数据JSON
        /// {key:"ID",source:1,target:2},{key:"Name",source:"张三",target:"李四"}
        /// </summary>
        /// <param name="target">当前数据对象</param>
        /// <param name="source">原数据对象</param>
        /// <param name="noEditProps">过滤不更新字段</param>
        public static string ByUpdate<T>(this T target, T source, params string[] noEditProps) where T : class
        {
            if (source == null) { return string.Empty; }

            List<string> result = new List<string>();
            if (noEditProps == null) { noEditProps = "ID,Operator,CreateTime".Split(','); }

            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!property.CanWrite) { continue; }
                if (noEditProps.Length > 0 && noEditProps.Equals(property.Name)) { continue; }

                string colName = property.GetTableColumnName();
                object newValue = property.GetValue(source, null) ?? "";
                object oldValue = property.GetValue(target, null) ?? "";

                if (!string.Equals(newValue.ToString(), oldValue.ToString()))
                {
                    property.SetValue(target, newValue, null);
                    result.Add(string.Concat("{", string.Format("key:{0},source:{1},target:{2}", colName, oldValue, newValue), "}"));
                }
            }

            if (result.Count > 0) { return string.Concat("{", string.Join(',', result), "}"); }

            return string.Empty;
        }
        /// <summary>
        /// 对比实体与字典集合数据并返回需要更新的数据JSON
        /// </summary>
        /// <param name="source">最新数据对象</param>
        /// <param name="noEditProps">过滤不更新字段</param>
        public static string ByUpdate<T>(this T source, IDictionary<string, object> fields, params string[] noEditProps) where T : class
        {
            if (fields == null) { return string.Empty; }

            List<string> result = new List<string>();
            if (noEditProps == null) { noEditProps = "ID,Operator,CreateTime".Split(','); }

            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!property.CanWrite) { continue; }
                if (noEditProps.Length > 0 && noEditProps.Equals(property.Name)) { continue; }
                if (!fields.Keys.Select(s => s.ToLower()).Contains(property.Name.ToLower())) { continue; }

                string colName = property.GetTableColumnName();
                object newValue = fields.GetValue(property.Name);
                object oldValue = property.GetValue(source, null) ?? "";

                if (!string.Equals(newValue.ToString(), oldValue.ToString()))
                {
                    property.SetValue(source, newValue, null);
                    result.Add(string.Concat("{", string.Format("key:{0},source:{1},target:{2}", colName, oldValue, newValue), "}"));
                }
            }

            if (result.Count > 0) { return string.Concat("{", string.Join(',', result), "}"); }

            return string.Empty;
        }

        /// <summary>
        /// 将集合对象数据转换为DataTable
        /// </summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source, bool column = true) where T : class
        {
            DataTable table = new DataTable();
            PropertyInfo[] columns = typeof(T).GetProperties();
            foreach (PropertyInfo property in columns)
            {
                string colName = property.Name; 
                if (column) { colName = property.GetTableColumnName(); }
                if (!string.IsNullOrEmpty(colName)) { table.Columns.Add(new DataColumn(colName)); }
            }

            foreach (T item in source)
            {
                DataRow newRow = table.NewRow();
                foreach (PropertyInfo property in columns)
                {
                    string colName = property.Name;
                    if (column) { colName = property.GetTableColumnName(); }
                    if (!string.IsNullOrEmpty(colName))
                    {
                        object value = property.GetValue(item, null);
                        if (value != null) { newRow[colName] = value; }
                    }
                }
                table.Rows.Add(newRow);
            }

            return table;
        }

        //========================================================================

        /// <summary>
        /// [自定义扩展] 获取对象属性元素扩展描述（DescriptionAttribute）
        /// </summary>
        public static string GetDescription(this PropertyInfo that)
        {
            if (that != null)
            {
                Attribute attribute = that.GetCustomAttribute(typeof(DescriptionAttribute), true);
                if (attribute != null)
                {
                    return ((DescriptionAttribute)attribute).Description;
                }
            }
            return string.Empty;
        }

        //========================================================================

        /// <summary>
        /// [自定义扩展] 根据KEY获取字典元素值
        /// </summary>
        public static string GetValue(this IDictionary<string, object> that, string key, object defval = null)
        {
            if (that != null && that.Keys.Select(s => s.ToLower()).Contains(key.ToLower()))
            {
                return (that.First(w => string.Equals(w.Key.ToLower(), key.ToLower())).Value ?? defval).ToString();
            }
            return string.Empty;
        }
    }
}
