using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AdminPowerDAL ---- 管理员权限配置信息 仓储实现
    /// </summary>
    public partial class AdminPowerDAL : GenericRepository<model.xbManage.AdminPowerInfo>, IRepository<model.xbManage.AdminPowerInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AdminPowerDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_admin_power";
            base.DbTable.PKey = "admin_id";
            base.DbTable.AutoNumber = false;
            base.DbTable.Fields = "agent_id,role_ids,role_group,agent_group,agent_spread".Split(',').ToList();
        }
    }
}
