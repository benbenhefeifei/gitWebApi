using System;
using System.Linq;
using System.Collections.Generic;
using hh.model.xbManage;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminAccountBLL ---- 管理员最后操作信息 业务逻辑处理（扩展）
    /// </summary>
    public partial class AdminLastBLL
    {
        /// <summary>
        /// 最后登录
        /// </summary>
        /// <param name="id">账户ID</param>
        /// <param name="times">登录时间</param>
        /// <param name="ecount">错误次数</param>
        public bool LastLogin(long id, long times, int ecount = 0)
        {
            IDictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("pass_error_num", ecount);
            if (ecount > 0) { fields.Add("login_time", times); }
            else { fields.Add("edit_pass_time", times); }

            IDictionary<string, object> wheres = new Dictionary<string, object>();
            wheres.Add("admin_id", id);

            return this.Storage.Updates(fields, wheres);
        }
    }
}
