/***********************************************
 * 版权声明：2017-2020 
 * 编写作者：吴文吉
 * 功能描述：数据库读写接口
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库写操作通用接口（扩展）
    /// </summary>
    public interface IWriter : System.IDisposable
    {
        /// <summary>
        /// 执行SQL语句并返回所执行的行数
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        int ExecuteNonQuery(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);

        /// <summary>
        /// 执行SQL语句并返回所执行返回结果
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        object ExecuteScalar(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);

        /// <summary>
        /// 批量操作数据
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="targetTable">目标数据表名</param>
        bool BulkCopy(System.Data.DataTable dataSource, string targetTable);
    }
}
