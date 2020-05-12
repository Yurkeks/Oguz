using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class OrderCurtainsController : Controller
    {
        private OrderDto orderDto;
        private readonly ApplicationDbContext _context;
        public OrderCurtainsController(ApplicationDbContext context)
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
            var styles = _context.Styles.Where(c => c.Category == category && c.Active).ToList();
            return View(styles);
        }
        [HttpGet]
        public IActionResult Fabric(Guid styleId)
        {
            // TODO: validation
            
            var style = _context.Styles.SingleOrDefault(c => c.Id == styleId);
            var materials = _context.Materials.Where(c => c.Category == style.Category && c.Active).ToList();
            orderDto = new OrderDto()
            {
                StyleId = styleId,
                Materials = materials
            };
            return View(orderDto);
        }
        public IActionResult Color(Guid materialId, Guid styleId)
        {
            var material = _context.Materials.Include(c => c.Colors).SingleOrDefault(m => m.Id == materialId);
            orderDto = new OrderDto()
            {
                StyleId = styleId,
                Material = material
            };
            return View(orderDto);
        }
        public IActionResult Size(OrderDto model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            orderDto = new OrderDto()
            {
                MaterialId = model.MaterialId,
                StyleId = model.StyleId,
                ColorId = model.ColorId
            };
            return View(orderDto);
        }
        //[HttpGet]
        //public IActionResult Completion(List<Size> sizes)
        //{
        //    foreach (var size in sizes)
        //    {
        //        size.OrderId = order.Id;
        //    } 
        //    _context.Sizes.AddRange(sizes);
        //    order.Sizes.AddRange(sizes);
        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult Completion(string email)
        //{
        //    ApplicationUser customer = _context.ApplicationUsers.FirstOrDefault(e => e.Email == email);
        //    if (customer == null)
        //    {
        //        customer = new ApplicationUser()
        //        {
        //            Email = email
        //        };
        //    }
        //    var discounts = _context.Discounts.Where(d => d.Active);
        //    order.Price = GetOrderPrice(order, discounts);
        //    return View();
        //}
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