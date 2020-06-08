using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthRoleBLL ---- 授权角色信息 业务逻辑处理
    /// </summary>
    public partial class AuthTokenBLL : GenericService<model.xbManage.AuthTokenInfo>, IService<model.xbManage.AuthTokenInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AuthTokenBLL() : base(new storage.xbManage.AuthTokenDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AuthTokenBLL _Instance = null;
        static readonly object _lock = new object();
        public static AuthTokenBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AuthTokenBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
