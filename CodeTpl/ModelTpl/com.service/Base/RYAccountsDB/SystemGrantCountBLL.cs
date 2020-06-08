/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述： - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:53
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:53 == wuwenji == 创建 ==  - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// SystemGrantCount ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class SystemGrantCountBLL : GenericService<model.RYAccountsDB.SystemGrantCount>, IService<model.RYAccountsDB.SystemGrantCount>
    {
        /// <summary>
        /// 初始化 SystemGrantCount ---  业务逻辑服务
        /// </summary>
        public SystemGrantCountBLL() : base(new hh.storage.RYAccountsDB.SystemGrantCountDAL())
        { 
            //base.Storage.DbTable.Name = "SystemGrantCount";
            //base.Storage.DbTable.PKey = "DateID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[RegisterMachine],[GrantScore],[GrantCount],[CollectDate]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static SystemGrantCountBLL _Instance = null;
        static readonly object _lock = new object();
        public static SystemGrantCountBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new SystemGrantCountBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
