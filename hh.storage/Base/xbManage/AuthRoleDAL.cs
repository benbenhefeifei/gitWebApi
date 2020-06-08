using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AuthRoleDAL ---- 授权角色信息 仓储实现
    /// </summary>
    public partial class AuthRoleDAL : GenericRepository<model.xbManage.AuthRoleInfo>, IRepository<model.xbManage.AuthRoleInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AuthRoleDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_auth_roles";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "name,group,state,remark,agent_id".Split(',').ToList();
        }
    }
}
