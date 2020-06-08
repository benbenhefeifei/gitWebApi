using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminPowerBLL ---- 管理员权限配置信息 业务逻辑处理
    /// </summary>
    public partial class AdminPowerBLL : GenericService<model.xbManage.AdminPowerInfo>, IService<model.xbManage.AdminPowerInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AdminPowerBLL() : base(new storage.xbManage.AdminPowerDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AdminPowerBLL _Instance = null;
        static readonly object _lock = new object();
        public static AdminPowerBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AdminPowerBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
