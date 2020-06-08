using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hh.webapi.Controllers.Area.Admin
{
    [Route("admin/account")]
    public class AccountController : Controller
    {
        // GET: api/values
        [HttpGet]
        [HttpPost]
        [Route("list/{token}")]
        public ApiResult List(string token)
        {
            return ResultHelper.Page(0, new List<object>(), 1, 20);
        }

    }
}
