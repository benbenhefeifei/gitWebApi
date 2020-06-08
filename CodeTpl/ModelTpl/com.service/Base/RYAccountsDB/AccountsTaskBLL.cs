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
    /// AccountsTask ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccountsTaskBLL : GenericService<model.RYAccountsDB.AccountsTask>, IService<model.RYAccountsDB.AccountsTask>
    {
        /// <summary>
        /// 初始化 AccountsTask ---  业务逻辑服务
        /// </summary>
        public AccountsTaskBLL() : base(new hh.storage.RYAccountsDB.AccountsTaskDAL())
        { 
            //base.Storage.DbTable.Name = "AccountsTask";
            //base.Storage.DbTable.PKey = "ID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[UserID],[TaskID],[KindID],[TaskType],[TaskObject],[Progress],[TimeLimit],[TaskStatus],[InputDate]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccountsTaskBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccountsTaskBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccountsTaskBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
