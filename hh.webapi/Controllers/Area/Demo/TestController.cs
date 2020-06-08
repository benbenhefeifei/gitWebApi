using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hh.model.RYAccountsDB;
using hh.server.RYAccountsDB;

namespace hh.webapi.Controllers.Area.Demo
{
    [Route("demo")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        [Route("list")]
        public ApiResult List(string token)
        {
            AccountsInfo account = AccountsInfoBLL.Instance.FindByKey("1", "UserID");
            return ResultHelper.Page(0, new List<object>(), 1, 20);
        }


        [HttpGet]
        [HttpPost]
        [Route("ListNew")]
        public string ListNew(string token)
        {
            List<AccountsInfo> account = AccountsInfoBLL.Instance.FindByPage();
            return account.ToJson();
        }
        
    }
}
