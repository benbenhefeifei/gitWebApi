using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AuthConfigDAL ---- 授权权限配置信息 仓储实现
    /// </summary>
    public partial class AuthConfigDAL : GenericRepository<model.xbManage.AuthConfigInfo>, IRepository<model.xbManage.AuthConfigInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AuthConfigDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_auth_config";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "type,res_id,ext_id,funcs".Split(',').ToList();
        }
    }
}
