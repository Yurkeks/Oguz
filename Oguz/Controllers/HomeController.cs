using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Swatches()
        //{
        //    var materials = _context.Materials.Include(c => c.Colors).Include(c => c.Brand).Where(m => m.Category == Category.Curtains || m.Category == Category.Shades).ToList();
        //    return View(materials);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Subscribe(string email)
        {
            if (_context.ApplicationUsers.Any(a => a.Email == email))
            {
                var customer = _context.ApplicationUsers.FirstOrDefault(e => e.Email == email);
                customer.IsSubscribe = true;
                _context.SaveChanges();
            }
            else
            {
                ApplicationUser customer = new ApplicationUser();
                customer.Id = Guid.NewGuid().ToString();
                customer.Email = email;
                customer.IsSubscribe = true;
                _context.Add(customer);
                _context.SaveChanges();
            }
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}
