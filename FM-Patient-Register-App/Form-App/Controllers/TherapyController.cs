using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Form_App.Controllers
{
    public class TherapyController : Controller
    {
        // GET: TherapyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TherapyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TherapyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TherapyController/Create
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

        // GET: TherapyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TherapyController/Edit/5
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

        // GET: TherapyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TherapyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
