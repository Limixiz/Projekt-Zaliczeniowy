using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Form_App.Models;

namespace Form_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return RedirectToAction("Add", "Patient");


        }

        public IActionResult Error(string msg)
        {
            return View(msg);
        }
    }
}
