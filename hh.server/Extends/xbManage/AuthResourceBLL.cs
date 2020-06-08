using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using com.xbao.db.server;
using hh.model.xbManage;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthResourceBLL ---- 授权资源信息 业务逻辑处理
    /// </summary>
    public partial class AuthResourceBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleids"></param>
        public List<AuthResourceInfo> FindByRole(string roleids)
        {
            List<AuthResourceInfo> result = new List<AuthResourceInfo>();

            string sqlCmd = "SELECT res_id AS id,funcs FROM tb_auth_config WHERE type='role' AND ext_id in(" + roleids + ")";
            IEnumerable<AuthResourceInfo> cofdata = this.Storage.Reader.Filter<AuthResourceInfo>(sqlCmd);

            IEnumerable<AuthResourceInfo> resdata = this.Filter(page: 0, limit: 0);

            cofdata.ToList().ForEach(confd =>
            {
                AuthResourceInfo resd = resdata.FirstOrDefault(w => w.ID == confd.ID);
                if (resd != null)
                {
                    AuthResourceInfo refd = new AuthResourceInfo()
                    {
                        ID = confd.ID,
                        PID = resd.PID,
                        Nav = resd.Nav,
                        Name = resd.Name,
                        Icon = resd.Icon,
                        Code = resd.Code,
                        Args = resd.Args,
                        Link = resd.Link,
                        Scort = resd.Scort,
                        State = resd.State,
                        Funcs = resd.Funcs
                    };
                    if (!string.IsNullOrEmpty(confd.Funcs))
                    {
                        refd.Funcs = confd.Funcs;
                    }
                    result.Add(refd);
                }
            });

            return result;
        }
    }
}
