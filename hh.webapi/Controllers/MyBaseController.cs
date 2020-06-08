using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hh.webapi.Controllers
{
    [ApiController]
    public class MyBaseController : ControllerBase
    {
        //// PUT Disable
        //[HttpPut]
        //public void Put() { }

        //// DELETE Disable
        //[HttpDelete]
        //public void Delete() { }

        /// <summary>
        /// 参数基础验证
        /// </summary>
        /// <param name="token">授权请求token，由登录接口获得</param>
        [NonAction]
        internal IDictionary<string, object> BaseCheck(string token)
        {
            

            IDictionary<string, object> keyValues = new Dictionary<string, object>();

            return keyValues;
        }
        #region 获取当前操作IP
        /// <summary>
        /// 获取当前操作IP
        /// </summary>
        [NonAction]
        internal string UserIP()
        {
            string userip = string.Empty;
            try
            {
                string resData = com.xbao.tools.helper.HttpClient.Get("2019.ip138.com/ic.asp");
                int start = resData.IndexOf("[") + 1;
                int end = resData.IndexOf("]", start);
                userip = resData.Substring(start, end - start);
            }
            catch
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length > 1)
                {
                    userip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                }
            }
            if (string.IsNullOrEmpty(userip))
            {
                userip = this.HttpContext.Connection.RemoteIpAddress.ToString();
                if (string.IsNullOrEmpty(userip))
                {
                    userip = this.HttpContext.Connection.LocalIpAddress.ToString();
                }
            }
            if (!userip.IsIpAddr()) { return "127.0.0.1"; }
            return userip;
        }
        #endregion
        #region 获取虚拟路径映射的 物理路径
        /// <summary>
        /// 获取虚拟路径映射的 物理路径
        /// </summary>
        /// <param name="path">虚拟路径地址</param>
        /// <returns>物理路径地址</returns>
        [NonAction]
        internal string MapPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (path.Contains("http")) { return path; }
                
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
                return System.IO.Path.Combine(baseDirectory, path);
            }
            return string.Empty;
        }
        #endregion
    }
}
