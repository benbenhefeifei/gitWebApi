using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using hh.server.xbManage;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hh.webapi.Controllers
{
    [Route("auth")]
    public class AuthController : MyBaseController
    {
        // GET｜POST: auth/access_token
        [HttpGet]
        [HttpPost]
        [Route("access_token")]
        public ApiResult GetAuthToken(string duid, string plat, string type)
        {
            string ip = this.UserIP();

            AuthTokenBLL.Instance.DisableHit(duid, plat, type);
            model.xbManage.AuthTokenInfo model = AuthTokenBLL.Instance.Create(plat, type, duid, ip);

            object access = new { access_token = model.Token, refresh_token = model.Refresh, expire_time = model.ExpireTime };
            return ResultHelper.Data(access);
        }
        // GET: auth/refresh_token/{refresh_token}
        [HttpGet]
        [HttpPost]
        [Route("refresh_token/{refresh_token}")]
        public ApiResult RefreshToken(string refresh_token)
        {
            if (string.IsNullOrEmpty(refresh_token)) { return ResultHelper.Info("12104", "刷新授权令牌Token为空."); }

            model.xbManage.AuthTokenInfo model = AuthTokenBLL.Instance.Find(refresh_token, "refresh");
            if (model != null)
            {
                model.ExpireTime = DateTime.Now.Timestamp() + (120 * 60 * 999 + 1);
                AuthTokenBLL.Instance.Update(model.ID, "expire_time", model.ExpireTime);
                object access = new { access_token = model.Token, refresh_token = model.Refresh, expire_time = model.ExpireTime };
                return ResultHelper.Data(access);
            }

            return ResultHelper.Info("12104", "无效的刷新授权令牌Token.");
        }

        // GET｜POST: auth/getsmscode/{token}?phone=
        [HttpGet]
        [HttpPost]
        [Route("getsmscode/{token}")]
        public ApiResult GetSmsCode(string token, string phone)
        {
            return ResultHelper.Info();
        }

        // GET: auth/login/{token}?name=?pass=
        [HttpGet]
        [Route("login/{token}")]
        public ApiResult Get(string token, string name, string pass)
        {
            if (string.IsNullOrEmpty(token)) { return ResultHelper.Info("12104", "请求授权令牌为空或不存在."); }
            if (string.IsNullOrEmpty(name)) { return ResultHelper.Info("12104", "登录账户参数为空."); }
            if (string.IsNullOrEmpty(pass)) { return ResultHelper.Info("12104", "登录密码参数为空."); }

            return ResultHelper.Data(new { token, name, pass });
            // return Manager.LoginHelper.AdminLogin(name, pass, token, UserIP());
        }

        // POST auth/login/{token}
        [HttpPost]
        [Route("login/{token}")]
        public ApiResult Post(string token, [FromBody] Models.Query.AdminLogin value)
        {
            if (string.IsNullOrEmpty(token)) { return ResultHelper.Info("12104", "请求授权令牌为空或不存在."); }

            return ResultHelper.Data(new { token, value.name, value.pass });
            // return Manager.LoginHelper.AdminLogin(value.name, value.pass, "", UserIP());
        }
    }
}
