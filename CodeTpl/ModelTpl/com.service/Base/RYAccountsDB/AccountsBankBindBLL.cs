﻿/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述：网站用户（会员）信息 - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 == 网站用户（会员）信息 - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// AccountsBankBind --- 网站用户（会员）信息 - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccountsBankBindBLL : GenericService<model.RYAccountsDB.AccountsBankBind>, IService<model.RYAccountsDB.AccountsBankBind>
    {
        /// <summary>
        /// 初始化 AccountsBankBind --- 网站用户（会员）信息 业务逻辑服务
        /// </summary>
        public AccountsBankBindBLL() : base(new hh.storage.RYAccountsDB.AccountsBankBindDAL())
        { 
            //base.Storage.DbTable.Name = "AccountsBankBind";
            //base.Storage.DbTable.PKey = "UserID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[IsLockBank],[TrueName],[BankName],[BankAccount],[BankAddress],[AlipayName],[AlipayAccount]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccountsBankBindBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccountsBankBindBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccountsBankBindBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
