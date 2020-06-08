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
    /// MessageVerCode ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class MessageVerCodeBLL : GenericService<model.RYAccountsDB.MessageVerCode>, IService<model.RYAccountsDB.MessageVerCode>
    {
        /// <summary>
        /// 初始化 MessageVerCode ---  业务逻辑服务
        /// </summary>
        public MessageVerCodeBLL() : base(new hh.storage.RYAccountsDB.MessageVerCodeDAL())
        { 
            //base.Storage.DbTable.Name = "MessageVerCode";
            //base.Storage.DbTable.PKey = "VerCode";
            //base.Storage.DbTable.AutoNumber = false;
            //base.Storage.DbTable.Fields = "[Mobile],[InsertTime]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static MessageVerCodeBLL _Instance = null;
        static readonly object _lock = new object();
        public static MessageVerCodeBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new MessageVerCodeBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
