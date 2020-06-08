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
    /// AndroidConfigure ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AndroidConfigureBLL : GenericService<model.RYAccountsDB.AndroidConfigure>, IService<model.RYAccountsDB.AndroidConfigure>
    {
        /// <summary>
        /// 初始化 AndroidConfigure ---  业务逻辑服务
        /// </summary>
        public AndroidConfigureBLL() : base(new hh.storage.RYAccountsDB.AndroidConfigureDAL())
        { 
            //base.Storage.DbTable.Name = "AndroidConfigure";
            //base.Storage.DbTable.PKey = "BatchID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[ServerID],[ServiceMode],[AndroidCount],[EnterTime],[LeaveTime],[EnterMinInterval],[EnterMaxInterval],[LeaveMinInterval],[LeaveMaxInterval],[TakeMinScore],[TakeMaxScore],[SwitchMinInnings],[SwitchMaxInnings],[AndroidCountMember0],[AndroidCountMember1],[AndroidCountMember2],[AndroidCountMember3],[AndroidCountMember4],[AndroidCountMember5]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AndroidConfigureBLL _Instance = null;
        static readonly object _lock = new object();
        public static AndroidConfigureBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AndroidConfigureBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
