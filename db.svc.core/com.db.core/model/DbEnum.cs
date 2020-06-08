using System;
using System.ComponentModel;

namespace com.xbao.db.core
{
    /// <summary>
    /// EQType ---- 查询操作类型
    /// </summary>
    public enum EQType
    {
        /// <summary>
        /// 新增操作
        /// </summary>
        [Description("新增")]
        INSERT = 1,

        /// <summary>
        /// 修改操作
        /// </summary>
        [Description("修改")]
        UPDATE = 2,

        /// <summary>
        /// 删除操作
        /// </summary>
        [Description("删除")]
        DELETE = 4,

        /// <summary>
        /// 获取行数条目操作
        /// </summary>
        [Description("条目")]
        TCOUNT = 5,

        /// <summary>
        /// 获取一条数据操作
        /// </summary>
        [Description("查询")]
        SELECT = 7,

        /// <summary>
        /// 获取多行数据操作
        /// </summary>
        [Description("遍历")]
        FILTER = 9
    }
    /// <summary>
    /// EDbType ---- 数据库类型
    /// </summary>
    public enum EDbType
    {
        /// <summary>
        /// Sql Server 数据库
        /// </summary>
        MSSQL = 101,

        /// <summary>
        /// Mysql 数据库
        /// </summary>
        MYSQL = 102,

        /// <summary>
        /// Oracle 数据库
        /// </summary>
        ORACLE = 202
    }
}
