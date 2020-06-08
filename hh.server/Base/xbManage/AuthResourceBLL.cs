using System;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthResourceBLL ---- 授权资源信息 业务逻辑处理
    /// </summary>
    public partial class AuthResourceBLL : GenericService<model.xbManage.AuthResourceInfo>, IService<model.xbManage.AuthResourceInfo>
    {
        /// <summary>
        /// 初始化 依赖仓储
        /// </summary>
        public AuthResourceBLL() : base(new storage.xbManage.AuthResourceDAL())
        {
        }

        #region 使用单例设计模式 获取服务对象
        static AuthResourceBLL _Instance = null;
        static readonly object _lock = new object();
        public static AuthResourceBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AuthResourceBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
