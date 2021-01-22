using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oguz.Data;

namespace Oguz.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IEnumerable<ApplicationUser> GetAllClients()
        {
            return _context.ApplicationUsers;
        }
    }
}