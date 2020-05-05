using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public IActionResult Swatches()
        {
            var materials = _context.Materials.Include(c => c.Colors).Include(c => c.Brand).Where(m => m.Category == Category.Шторы || m.Category == Category.Гардины).ToList();
            return View(materials);
        }

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
            if (_context.Customers.Any(a => a.Email == email))
            {
                var customer = _context.Customers.FirstOrDefault(e => e.Email == email);
                customer.IsSubscribe = true;
                _context.SaveChanges();
            }
            else
            {
                Customer customer = new Customer();
                customer.Id = Guid.NewGuid();
                customer.Email = email;
                customer.IsSubscribe = true;
                _context.Add(customer);
                _context.SaveChanges();
            }
        }
    }
}
