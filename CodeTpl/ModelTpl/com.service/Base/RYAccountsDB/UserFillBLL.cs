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
    /// T_UserFill ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class UserFillBLL : GenericService<model.RYAccountsDB.UserFill>, IService<model.RYAccountsDB.UserFill>
    {
        /// <summary>
        /// 初始化 T_UserFill ---  业务逻辑服务
        /// </summary>
        public UserFillBLL() : base(new hh.storage.RYAccountsDB.UserFillDAL())
        { 
            //base.Storage.DbTable.Name = "T_UserFill";
            //base.Storage.DbTable.PKey = "UserID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[Amount],[FirstFillDate],[LastFillDate],[OffLineCnt],[OffLineAmt]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static UserFillBLL _Instance = null;
        static readonly object _lock = new object();
        public static UserFillBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new UserFillBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
