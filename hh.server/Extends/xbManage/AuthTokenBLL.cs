using System;
using System.Linq;
using System.Security;
using System.Collections.Generic;
using com.xbao.db.server;
using Newtonsoft.Json;

namespace hh.server.xbManage
{
    /// <summary>
    /// AuthRoleBLL ---- 授权角色信息 业务逻辑处理
    /// </summary>
    public partial class AuthTokenBLL
    {
        /// <summary>
        /// 创建新的授权令牌
        /// </summary>
        /// <param name="duid">设备标识</param>
        /// <param name="ip">设备IP</param>
        public model.xbManage.AuthTokenInfo Create(string plat, string type, string duid, string ip)
        {
            long times = DateTime.Now.Timestamp();
            object tdata = new { plat = plat, type = type, user_ip = ip, device_id = duid };
            string token = JsonConvert.SerializeObject(tdata);
            model.xbManage.AuthTokenInfo authTokenInfo =
                new model.xbManage.AuthTokenInfo()
                {
                    State = 1,
                    UserID = 0,
                    Plat = plat,
                    Type = type,
                    UserIP = ip,
                    DeviceID = duid,
                    Token = SecurityFactory.SHA1.Encrypt(token).ToLower(),
                    Refresh = SecurityFactory.SHA256.Encrypt(token, times.ToString()).ToLower(),
                    CreateTime = times,
                    ExpireTime = times + (120 * 60 * 999 + 1)
                };

            authTokenInfo = this.Insert(authTokenInfo);
            return authTokenInfo;
        }
        /// <summary>
        /// 根据Token获取当前有效的授权信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public model.xbManage.AuthTokenInfo Find(string token, string type = "token")
        {
            IDictionary<string, object> wheres = new Dictionary<string, object>();
            wheres.Add("state", 1);
            if (type == "token") { wheres.Add("token", token); }
            if (type == "refresh") { wheres.Add("refresh", token); }
            return this.Find(wheres);
        }

        /// <summary>
        /// 更新历史 Token 为无效
        /// </summary>
        /// <param name="duid"></param>
        /// <returns></returns>
        public bool DisableHit(string duid, string plat, string type)
        {
            IDictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("state", 0);

            IDictionary<string, object> wheres = new Dictionary<string, object>();
            wheres.Add("plat", plat);
            wheres.Add("type", type);
            wheres.Add("duid", duid);
            this.Remove(wheres);

            return this.Update(fields, wheres);
        }
    }
}
