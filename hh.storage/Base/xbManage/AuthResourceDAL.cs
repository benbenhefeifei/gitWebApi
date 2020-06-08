using System;
using System.Linq;
using com.xbao.db.storage;

namespace hh.storage.xbManage
{
    /// <summary>
    /// AuthResourceDAL ---- 授权资源信息 仓储实现
    /// </summary>
    public partial class AuthResourceDAL : GenericRepository<model.xbManage.AuthResourceInfo>, IRepository<model.xbManage.AuthResourceInfo>
    {
        /// <summary>
        /// 初始化 数据表信息
        /// </summary>
        public AuthResourceDAL() : base("xbManage")
        {
            base.DbTable.Name = "tb_auth_resource";
            base.DbTable.PKey = "id";
            base.DbTable.AutoNumber = true;
            base.DbTable.Fields = "pid,nav,code,name,icon,line,args,scort,state,funcs".Split(',').ToList();
        }
    }
}
