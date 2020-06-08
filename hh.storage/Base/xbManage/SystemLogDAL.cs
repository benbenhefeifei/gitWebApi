using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// SystemLogDAL ---- 系统日志信息 仓储实现
    /// </summary>
    public partial class SystemLogDAL : GenericRepository<model.xbManage.SystemLogInfo>, IRepository<model.xbManage.SystemLogInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public SystemLogDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_log_operate";
            base.DbTable.PKey = "";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "".Split(',').ToList();
        }

    }
}
