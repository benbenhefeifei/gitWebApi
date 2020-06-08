using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthRoleBLL ---- 授权角色信息 业务逻辑处理
    /// </summary>
    public partial class AuthRoleBLL : GenericService<model.xbManage.AuthRoleInfo>, IService<model.xbManage.AuthRoleInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AuthRoleBLL() : base(new storage.xbManage.AuthRoleDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AuthRoleBLL _Instance = null;
        static readonly object _lock = new object();
        public static AuthRoleBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AuthRoleBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
