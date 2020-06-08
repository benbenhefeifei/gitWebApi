using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// SystemLogBLL ---- 系统日志信息 业务逻辑处理
    /// </summary>
    public partial class SystemLogBLL : GenericService<model.xbManage.SystemLogInfo>, IService<model.xbManage.SystemLogInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public SystemLogBLL() : base(new storage.xbManage.SystemLogDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static SystemLogBLL _Instance = null;
        static readonly object _lock = new object();
        public static SystemLogBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new SystemLogBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
