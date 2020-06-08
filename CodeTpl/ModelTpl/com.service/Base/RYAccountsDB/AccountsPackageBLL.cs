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
    /// AccountsPackage ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccountsPackageBLL : GenericService<model.RYAccountsDB.AccountsPackage>, IService<model.RYAccountsDB.AccountsPackage>
    {
        /// <summary>
        /// 初始化 AccountsPackage ---  业务逻辑服务
        /// </summary>
        public AccountsPackageBLL() : base(new hh.storage.RYAccountsDB.AccountsPackageDAL())
        { 
            //base.Storage.DbTable.Name = "AccountsPackage";
            //base.Storage.DbTable.PKey = "UserID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[GoodShowID],[GoodsSortID],[GoodsCount],[PushTime]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccountsPackageBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccountsPackageBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccountsPackageBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
