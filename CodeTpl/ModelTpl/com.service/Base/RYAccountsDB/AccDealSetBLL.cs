/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述：玩家提款全局配置表New - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:53
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:53 == wuwenji == 创建 == 玩家提款全局配置表New - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// T_Acc_DealSet --- 玩家提款全局配置表New - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccDealSetBLL : GenericService<model.RYAccountsDB.AccDealSet>, IService<model.RYAccountsDB.AccDealSet>
    {
        /// <summary>
        /// 初始化 T_Acc_DealSet --- 玩家提款全局配置表New 业务逻辑服务
        /// </summary>
        public AccDealSetBLL() : base(new hh.storage.RYAccountsDB.AccDealSetDAL())
        { 
            //base.Storage.DbTable.Name = "T_Acc_DealSet";
            //base.Storage.DbTable.PKey = "ID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[IsOpen],[IsSale],[GameCnt],[WeekOpenDay],[Shour],[Ehour],[DailyApplyTimes],[BalancePrice],[MinBalance],[CounterFee],[MinCounterFee],[MinPlayerScore],[DrawMultiple],[IsMobileSale]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccDealSetBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccDealSetBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccDealSetBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
