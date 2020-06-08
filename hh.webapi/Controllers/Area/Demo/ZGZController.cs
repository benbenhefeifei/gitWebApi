using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hh.webapi.Controllers.Area.Demo
{
    public class ZGZController : Controller
    {
        // GET: ZGZController zgz
        public ActionResult Index()
        {
            return View();
        }

        // GET: ZGZController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ZGZController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZGZController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZGZController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZGZController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZGZController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZGZController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            int x = 1;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
    }
}
