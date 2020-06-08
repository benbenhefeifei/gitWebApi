using System;
using System.Linq;
using System.Collections.Generic;
using hh.model.xbManage;
using hh.server.xbManage;
using com.xbao.tools.helper;
using System.Security;

namespace hh.webapi.Manager
{
    public class LoginHelper
    {
        public static ApiResult AdminLogin(string name, string pass, string duid, string userip, string mode = "password")
        {
            AdminAccountInfo account = AdminAccountBLL.Instance.FindByKey(name);
            AdminLastInfo last = AdminLastBLL.Instance.Find(account.ID);
            if (account == null)
            {
                return ResultHelper.Info("12112", "登录账号输入错误.");
            }
            long nowtimes = DateTime.Now.Timestamp();
            // 密码登录
            if (mode == "password")
            {
                string passwd = System.Security.SecurityFactory.MD532.Encrypt(pass, account.PassSalt);
                if (account.PassLogin != passwd)
                {
                    int m30 = (30 * 60 * 999 + 1);
                    long logtimes = last.LoginTime;
                    if (last.PassErrorNum >= 5)
                    {
                        AdminAccountBLL.Instance.ChangeState(account.ID, -1);
                        return ResultHelper.Info("12113", "登录密码连续输入错误超过[5]次,账户已暂时冻结.");
                    }
                    if (last.PassErrorNum == 3 && (nowtimes - last.LoginTime) <= m30)
                    {
                        string dtmi = Math.Round((m30 - (nowtimes - last.LoginTime)) / 1000.0 / 60.0, 0).ToString();
                        return ResultHelper.Info("12113", "登录密码连续输入错误[3]次,请[" + dtmi + "]分钟后再试.");
                    }
                    AdminLastBLL.Instance.LastLogin(account.ID, nowtimes, last.PassErrorNum + 1);
                    return ResultHelper.Info("12113", "登录密码输入错误.");
                }
            }
            // 验证码登录
            if (mode == "code")
            {

            }

            AdminPowerInfo power = AdminPowerBLL.Instance.Find(account.ID);
            if (power == null)
            {
                return ResultHelper.Info("12110", "您没有任何访问权限1.");
            }
            if (string.IsNullOrEmpty(power.RoleIds))
            {
                return ResultHelper.Info("12110", "您没有任何访问权限2.");
            }
            List<AuthResourceInfo> powerds = AuthResourceBLL.Instance.FindByRole(power.RoleIds);

            string token = SecurityFactory.MD532.Encrypt(duid + account.ID + nowtimes);
            // 记录登录日志
            AdminLoginLogInfo logd = new AdminLoginLogInfo()
            {
                UserID = account.ID,
                UserName = account.RealName,
                LoginIP = userip,
                LoginTime = nowtimes,
                UserToken = token,
                LogoutTime = 0,
                UserType = 0,
                LoginDevice = duid
            };
            logd = AdminLoginLogBLL.Instance.Insert(logd);

            IDictionary<string, object> userd = new Dictionary<string, object>();
            userd.Add("online", 1);
            userd.Add("name", account.RealName);
            userd.Add("fpass", last.PassErrorNum < 1);
            userd.Add("epass", last.PassErrorNum < 1);
            userd.Add("online_time", last.LogTime);
            userd.Add("login_count", last.LogCount + 1);
            userd.Add("login_ip", new { prev = last.LoginIP, now = logd.LoginIP });
            userd.Add("login_time", new { prev = last.LoginTime, now = logd.LoginTime });
            userd.Add("access_auth", power);
            if (last.EditPassTime > 0)
            {
                userd["epass"] = (nowtimes - last.EditPassTime) >= (account.PassEtime * 24 * 60 * 60 * 100);
            }

            IDictionary<string, object> resultd = new Dictionary<string, object>();
            resultd.Add("token", token);
            resultd.Add("profile", userd);
            resultd.Add("navbar", new ResourceHelper().ToNavbar(powerds));
            return ResultHelper.Data(resultd);
        }
    }
}
