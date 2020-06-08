using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminAccountBLL ---- 管理员基本信息 业务逻辑处理
    /// </summary>
    public partial class AdminAccountBLL : GenericService<model.xbManage.AdminAccountInfo>, IService<model.xbManage.AdminAccountInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AdminAccountBLL() : base(new storage.xbManage.AdminAccountDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AdminAccountBLL _Instance = null;
        static readonly object _lock = new object();
        public static AdminAccountBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AdminAccountBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
