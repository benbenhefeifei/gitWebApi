/***********************************************
 * 版权声明：2017-2020 
 * 编写作者：吴文吉
 * 功能描述：数据库只读接口
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库读操作通用接口（扩展）
    /// </summary>
    public interface IReader : System.IDisposable
    {
        /// <summary>
        /// 执行SQL语句并返回执行结果
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        T Find<T>(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);
        /// <summary>
        /// 执行SQL语句并返回执行结果的数据行数
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        long Count(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);
        /// <summary>
        /// 执行SQL语句并返回执行结果的数据集合
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        System.Collections.Generic.IEnumerable<T> Filter<T>(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);

        /// <summary>
        /// 执行SQL语句并返回执行结果的数据集合
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        System.Data.DataTable ExecuteToDataTable(string commandText, object paramaters = null, System.Data.CommandType commandType = System.Data.CommandType.Text);
    }
}
