using System;

namespace com.xbao.db.core
{
    public class BaseQuery
    {
        /// <summary>
        /// 获取或设置 查询自定义字段
        /// </summary>
        public string Fields { get; set; }
        /// <summary>
        /// 获取或设置 查询排序
        /// </summary>
        public string ReOrder { get; set; }
    }
}
