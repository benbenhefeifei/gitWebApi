using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminLastBLL ---- 管理员最后操作信息 业务逻辑处理
    /// </summary>
    public partial class AdminLastBLL : GenericService<model.xbManage.AdminLastInfo>, IService<model.xbManage.AdminLastInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AdminLastBLL() : base(new storage.xbManage.AdminLastDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AdminLastBLL _Instance = null;
        static readonly object _lock = new object();
        public static AdminLastBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AdminLastBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
