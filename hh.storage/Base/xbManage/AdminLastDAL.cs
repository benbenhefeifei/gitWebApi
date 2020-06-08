using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AdminLastDAL ---- 管理员最后操作信息 仓储实现
    /// </summary>
    public partial class AdminLastDAL : GenericRepository<model.xbManage.AdminLastInfo>, IRepository<model.xbManage.AdminLastInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AdminLastDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_admin_extends";
            base.DbTable.PKey = "admin_id";
            base.DbTable.AutoNumber = false;
            base.DbTable.Fields = "online,log_count,log_time,band_ip,login_ip,login_time,login_token,login_device,pass_error_num,edit_pass_time".Split(',').ToList();
        }
    }
}
