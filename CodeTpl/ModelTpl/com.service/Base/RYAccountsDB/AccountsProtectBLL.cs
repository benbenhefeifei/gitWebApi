/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述： - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 ==  - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// AccountsProtect ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccountsProtectBLL : GenericService<model.RYAccountsDB.AccountsProtect>, IService<model.RYAccountsDB.AccountsProtect>
    {
        /// <summary>
        /// 初始化 AccountsProtect ---  业务逻辑服务
        /// </summary>
        public AccountsProtectBLL() : base(new hh.storage.RYAccountsDB.AccountsProtectDAL())
        { 
            //base.Storage.DbTable.Name = "AccountsProtect";
            //base.Storage.DbTable.PKey = "ProtectID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[UserID],[Question1],[Response1],[Question2],[Response2],[Question3],[Response3],[PassportID],[PassportType],[SafeEmail],[CreateIP],[ModifyIP],[CreateDate],[ModifyDate]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccountsProtectBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccountsProtectBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccountsProtectBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
