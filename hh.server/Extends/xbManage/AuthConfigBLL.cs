using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using com.xbao.db.server;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthResourceBLL ---- 授权资源信息 业务逻辑处理
    /// </summary>
    public partial class AuthConfigBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleids"></param>
        public object FindByRole(string type, string roleids)
        {
            IDictionary<string, string> wheres = new Dictionary<string, string>();
            wheres.Add("type", type);
            string sqlCmd = "SELECT res_id,funcs FROM tb_auth_config WHERE type='" + type + "' AND ext_id in(" + roleids + ")";
            DataTable table = this.Storage.Reader.ExecuteToDataTable(sqlCmd);

            return null;
        }


    }
}
