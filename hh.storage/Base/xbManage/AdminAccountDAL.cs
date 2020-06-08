using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AdminAccountDAL ---- 管理员基本信息 仓储实现
    /// </summary>
    public partial class AdminAccountDAL : GenericRepository<model.xbManage.AdminAccountInfo>, IRepository<model.xbManage.AdminAccountInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AdminAccountDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_admin_account";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "state,login_id,real_name,pass_salt,pass_login,pass_auth,email,mobile,email_active,mobile_active,pass_etime,create_time".Split(',').ToList();
        }
    }
}
