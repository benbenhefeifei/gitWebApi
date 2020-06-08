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
    /// rds168411 ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class Rds168411BLL : GenericService<model.RYAccountsDB.Rds168411>, IService<model.RYAccountsDB.Rds168411>
    {
        /// <summary>
        /// 初始化 rds168411 ---  业务逻辑服务
        /// </summary>
        public Rds168411BLL() : base(new hh.storage.RYAccountsDB.Rds168411DAL())
        { 
            //base.Storage.DbTable.Name = "rds168411";
            //base.Storage.DbTable.PKey = "DrawID";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[UserID],[ChairID],[Score],[Grade],[Revenue],[UserMedal],[PlayTimeCount],[DBQuestID],[InoutIndex],[InsertTime]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static Rds168411BLL _Instance = null;
        static readonly object _lock = new object();
        public static Rds168411BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new Rds168411BLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
