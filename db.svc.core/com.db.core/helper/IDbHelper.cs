/***********************************************
 * 版权声明：2017-2020 
 * 编写作者：吴文吉
 * 功能描述：数据库操作接口（读写分离）
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;

namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库操作接口（读写分离）
    /// </summary>
    public interface IDbHelper : System.IDisposable
    {
        /// <summary>
        /// 数据库写入操作命令接口B
        /// </summary>
        IWriter Writer { get; }
        /// <summary>
        /// 数据库读取操作命令接口
        /// </summary>
        IReader Reader { get; }
    }
}
