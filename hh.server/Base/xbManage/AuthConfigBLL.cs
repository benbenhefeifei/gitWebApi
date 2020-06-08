using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthConfigBLL ---- 授权权限配置信息 业务逻辑处理
    /// </summary>
    public partial class AuthConfigBLL : GenericService<model.xbManage.AuthConfigInfo>, IService<model.xbManage.AuthConfigInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AuthConfigBLL() : base(new storage.xbManage.AuthConfigDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AuthConfigBLL _Instance = null;
        static readonly object _lock = new object();
        public static AuthConfigBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AuthConfigBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
