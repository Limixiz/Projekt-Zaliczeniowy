using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Form_App.Controllers
{
    public class Dashboard : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        
    }
}
