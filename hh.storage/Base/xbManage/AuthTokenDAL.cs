using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AuthRoleDAL ---- 授权角色信息 仓储实现
    /// </summary>
    public partial class AuthTokenDAL : GenericRepository<model.xbManage.AuthTokenInfo>, IRepository<model.xbManage.AuthTokenInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AuthTokenDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_access_token";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "refresh,plat,type,duid,usip,user_id,expire_time,create_time,state".Split(',').ToList();
        }
    }
}
