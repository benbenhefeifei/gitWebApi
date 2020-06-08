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
    /// RecordMedalChange ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class RecordMedalChangeBLL : GenericService<model.RYAccountsDB.RecordMedalChange>, IService<model.RYAccountsDB.RecordMedalChange>
    {
        /// <summary>
        /// 初始化 RecordMedalChange ---  业务逻辑服务
        /// </summary>
        public RecordMedalChangeBLL() : base(new hh.storage.RYAccountsDB.RecordMedalChangeDAL())
        { 
            //base.Storage.DbTable.Name = "RecordMedalChange";
            //base.Storage.DbTable.PKey = "RecordID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[UserID],[SrcMedal],[TradeMedal],[TypeID],[ClientIP],[CollectDate],[CollectNote]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static RecordMedalChangeBLL _Instance = null;
        static readonly object _lock = new object();
        public static RecordMedalChangeBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new RecordMedalChangeBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
