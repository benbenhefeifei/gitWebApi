using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AdminLoginLogDAL ---- 管理员登录日志信息 仓储实现
    /// </summary>
    public partial class AdminLoginLogDAL : GenericRepository<model.xbManage.AdminLoginLogInfo>, IRepository<model.xbManage.AdminLoginLogInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AdminLoginLogDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_log_login";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "login_ip,login_time,logout_time,login_device,user_id,user_name,user_type,user_token".Split(',').ToList();
        }
    }
}
