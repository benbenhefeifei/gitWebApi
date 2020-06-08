using System;
using System.Linq;
using System.Collections.Generic;
using hh.model.xbManage;

namespace hh.server.xbManage
{
    /// <summary>
    /// AdminAccountBLL ---- 管理员基本信息 业务逻辑处理（扩展）
    /// </summary>
    public partial class AdminAccountBLL
    {
        /// <summary>
        /// 根据用户指定KEY 获取用户基本信息
        /// </summary>
        /// <param name="value">KEY值</param>
        /// <param name="key">KEY</param>
        public AdminAccountInfo FindByKey(string value, string key = "login_id")
        {
            IDictionary<string, string> where = new Dictionary<string, string>();
            where.Add(key, value);
            return this.Find(where);
        }

        public bool ChangeState(long id, int state)
        {
            IDictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("state", state);

            IDictionary<string, object> wheres = new Dictionary<string, object>();
            wheres.Add("id", id);

            return this.Storage.Updates(fields, wheres);
        }
    }
}
