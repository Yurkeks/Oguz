using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Oguz.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Curtains()
        {
            return View();
        }
        public IActionResult Pillows()
        {
            return View();
        }
        public IActionResult CurtainsInfo(Guid id)
        {
            return View();
        }
        public IActionResult PillowsInfo(Guid id)
        {
            return View();
        }
    }
}