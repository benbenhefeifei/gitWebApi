/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述：提现卡号配置表 - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:53
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:53 == wuwenji == 创建 == 提现卡号配置表 - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// T_BankCard --- 提现卡号配置表 - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class BankCardBLL : GenericService<model.RYAccountsDB.BankCard>, IService<model.RYAccountsDB.BankCard>
    {
        /// <summary>
        /// 初始化 T_BankCard --- 提现卡号配置表 业务逻辑服务
        /// </summary>
        public BankCardBLL() : base(new hh.storage.RYAccountsDB.BankCardDAL())
        { 
            //base.Storage.DbTable.Name = "T_BankCard";
            //base.Storage.DbTable.PKey = "ID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[RealName],[BankName],[BankNo],[BankCity],[BankAddress],[Nullity],[BankCode],[Province]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static BankCardBLL _Instance = null;
        static readonly object _lock = new object();
        public static BankCardBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new BankCardBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
