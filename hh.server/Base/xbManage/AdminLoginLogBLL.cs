using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminLoginLogBLL ---- 管理员登录日志信息 业务逻辑处理
    /// </summary>
    public partial class AdminLoginLogBLL : GenericService<model.xbManage.AdminLoginLogInfo>, IService<model.xbManage.AdminLoginLogInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AdminLoginLogBLL() : base(new storage.xbManage.AdminLoginLogDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AdminLoginLogBLL _Instance = null;
        static readonly object _lock = new object();
        public static AdminLoginLogBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AdminLoginLogBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
