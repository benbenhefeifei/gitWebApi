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
    /// T_RegGrantError ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class RegGrantErrorBLL : GenericService<model.RYAccountsDB.RegGrantError>, IService<model.RYAccountsDB.RegGrantError>
    {
        /// <summary>
        /// 初始化 T_RegGrantError ---  业务逻辑服务
        /// </summary>
        public RegGrantErrorBLL() : base(new hh.storage.RYAccountsDB.RegGrantErrorDAL())
        { 
            //base.Storage.DbTable.Name = "T_RegGrantError";
            //base.Storage.DbTable.PKey = "UserID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[Score],[CollectDate]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static RegGrantErrorBLL _Instance = null;
        static readonly object _lock = new object();
        public static RegGrantErrorBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new RegGrantErrorBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
