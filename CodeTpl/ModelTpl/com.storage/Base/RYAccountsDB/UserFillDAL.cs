﻿/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据仓储服务（可扩展）
* 创建时间：2020-06-08 13:44:54
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:54 == wuwenji == 创建 ==  - 数据仓储服务
* *********************************************/

using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.RYAccountsDB
{
    /// <summary>
    ///  - 数据仓储服务（可扩展）
    /// </summary>
    public partial class UserFillDAL : GenericRepository<model.RYAccountsDB.UserFill>, IRepository<model.RYAccountsDB.UserFill>
    {
        public UserFillDAL() : base("RYAccountsDB")
        {
            base.DbTable.Name = "T_UserFill";
            base.DbTable.PKey = "UserID";
            base.DbTable.AutoNumber = false;//主建是否自增，如果不自增插入的时候要赋值
            base.DbTable.Fields = "[Amount],[FirstFillDate],[LastFillDate],[OffLineCnt],[OffLineAmt]".Split(',').ToList();
        }
    }
}
