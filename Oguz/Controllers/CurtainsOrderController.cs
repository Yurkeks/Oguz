using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class CurtainsOrderController : Controller
    {
        private Order order = default;
        private readonly ApplicationDbContext _context;
        public CurtainsOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(Category category)
        {
            order = new Order();
            return RedirectToAction("Style", category);
        }
        [HttpGet]
        public IActionResult Style(Category category)
        {
            var styles = _context.Styles.Where(c => c.Category == category && c.Active).ToList();
            return View(styles);
        }
        [HttpGet]
        public IActionResult Fabric(Guid styleId, Category category)
        {
            order.StyleId = styleId;
            var materials = _context.Materials.Where(c => c.Category == category && c.Active).ToList();
            return View(materials);
        }
        public IActionResult Color(Guid materialId)
        {
            order.MaterialId = materialId;
            var colors = _context.Colors.Where(c => c.MaterialId == materialId && c.Active).ToList();
            return View(colors);
        }
        public IActionResult Size(Guid colorId)
        {
            order.ColorId = colorId;
            return View();
        }
        [HttpGet]
        public IActionResult Completion(List<Size> sizes)
        {
            foreach (var size in sizes)
            {
                size.OrderId = order.Id;
            } 
            _context.Sizes.AddRange(sizes);
            order.Sizes.AddRange(sizes);
            return View(order);
        }
        [HttpPost]
        public IActionResult Completion(string email)
        {
            ApplicationUser customer = _context.ApplicationUsers.FirstOrDefault(e => e.Email == email);
            if (customer == null)
            {
                customer = new ApplicationUser()
                {
                    Email = email
                };
            }
            var discounts = _context.Discounts.Where(d => d.Active);
            order.Price = GetOrderPrice(order, discounts);
            return View();
        }
        public int GetOrderPrice(Order order, IEnumerable<Discount> discounts)
        {
            var productSquare = GetProductSquare(order.Sizes) + order.Customer.Amount;
            var userDiscount = 0;
            foreach (var discount in discounts)
            {
                if (productSquare >= discount.LinearMeters)
                {
                    userDiscount = discount.Value;
                }
            }
            return order.Material.Cost * productSquare * (100 - userDiscount);
        }
        public int GetProductSquare(List<Size> sizes)
        {
            int square = 0;
            foreach (var size in sizes)
            {
                square += size.Height * size.Width;
            }
            return square;
        }
    }
}