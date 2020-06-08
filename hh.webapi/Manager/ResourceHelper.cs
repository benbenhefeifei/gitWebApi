using System;
using System.Collections.Generic;
using System.Linq;
using hh.model.xbManage;

namespace hh.webapi.Manager
{
    public class ResourceHelper
    {
        public IDictionary<string, string> Funcs
        {
            get
            {
                IDictionary<string, string> result = new Dictionary<string, string>();

                result.Add("list", "分页");
                result.Add("export", "导出");
                result.Add("print", "打印");
                result.Add("config", "配置");
                result.Add("delete", "删除");
                result.Add("audit", "审核");
                result.Add("push", "添加");
                result.Add("edit", "修改");
                result.Add("look", "查看");
                result.Add("cols", "过滤");

                return result;
            }
        }

        public List<Models.Navbar> ToNavbar(List<AuthResourceInfo> datas, long pid = 0)
        {
            List<Models.Navbar> result = new List<Models.Navbar>();

            datas.Where(w => w.PID == pid).ToList().ForEach(item =>
            {
                Models.Navbar navbar = new Models.Navbar()
                {
                    Key = item.Code,
                    Name = item.Name,
                    Icon = item.Icon,
                    Link = item.Link
                };
                navbar.Children = this.ToNavbar(datas, item.ID);
                result.Add(navbar);
            });

            return result;
        }

        public List<Models.ResPower> ToPower(List<AuthResourceInfo> datas, long pid = 0)
        {
            List<Models.ResPower> result = new List<Models.ResPower>();

            datas.Where(w => w.PID == pid).ToList().ForEach(item =>
            {
                Models.ResPower power = new Models.ResPower()
                {
                    ID = "k" + item.ID,
                    Field = "key" + item.ID,
                    Title = item.Name,
                    Spread = item.PID == 0
                };
                power.Children = this.ToPower(datas, item.ID);
                if (pid > 0 && power.Children.Count <= 0)
                {
                    if (!string.IsNullOrEmpty(item.Funcs))
                    {
                        item.Funcs.Split(',').ToList().Distinct()
                        .Select(kval => new Models.ResPower()
                        {
                            ID = "k" + item.ID + "_" + kval,
                            Field = "key" + item.ID + "_" + kval,
                            Title = Funcs[kval],
                            Spread = false,
                            Children = new List<Models.ResPower>()
                        });
                    }
                }
                result.Add(power);
            });

            return result;
        }
    }
}
