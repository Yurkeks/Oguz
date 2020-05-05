using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(Category category)
        {
            return RedirectToAction("Style", category);
        }
        [HttpGet]
        public IActionResult Style(Category category)
        {
            var styles = _context.Styles.Where(c => c.Category == category).ToList(); 
            return View(styles);
        }
        public IActionResult Fabric(Guid styleId, Category category)
        {
            var materials = _context.Materials.Where(c => c.Category == category).ToList();
            var order = new Order()
            {
                StyleId = styleId
            };
            return View();
        }
        public IActionResult Color()
        {

            return View();
        }
        public IActionResult Size()
        {
            return View();
        }
        public IActionResult Completion()
        {
            return View();
        }
    }
}