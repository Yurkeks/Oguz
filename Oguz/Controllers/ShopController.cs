using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oguz.Data;

namespace Oguz.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
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
            var result = _context.Curtains.FirstOrDefault(i => i.Id == id);
            return View(result);
        }
        public IActionResult PillowsInfo(Guid id)
        {
            var result = _context.Pillows.FirstOrDefault(u => u.Id == id);
            return View(result);
        }
    }
}