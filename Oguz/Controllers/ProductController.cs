using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class ProductController : Controller
    {
        //private ApplicationDbContext db;
        //public ProductController(ApplicationDbContext db)
        //{
        //    this.db = db;
        //}
        //public IActionResult Index()
        //{
        //    return RedirectToAction("Style");
        //}
        //public IActionResult Style(Category category)
        //{
        //    Style style = default;
        //    if (!category.Equals(default))
        //    {
        //        style = db.Styles.Where(s => s.Category == category).FirstOrDefault();
        //    }
        //    return View(style);
        //}
        //[HttpPost]
        //public IActionResult Style(Guid styleId)
        //{
        //    var product = db.Products.Where(x => x.StyleId == styleId).First(); 
        //    if (product.Equals(null))
        //    {
        //        return View("Error"); // TODO: create error view or something else 
        //    }
        //    return RedirectToAction("Fabric", product);
        //}
        //public IActionResult Fabric(Product product)
        //{
        //    var order = new Order();
        //    ViewBag.Materials = db.Materials.Where(m => m.Category == product.Style.Category).ToList();
        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult Fabric(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", "some error");
        //    }
        //    return RedirectToAction("Color", order);
        //}
        //public IActionResult Color(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", "some error");
        //    }
        //    ViewBag.Colors  = (List<Color>)db.Materials.Where(m => m.Id == order.Material.Id).Select(c => c.Colors);
        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult Color(Order order, Guid colorId)
        //{
        //    order.Material.ColorId = colorId;
        //    return RedirectToAction("Size", order);
        //}
        //public IActionResult Size()
        //{

        //    return View();
        //}
        /*
         *  private ApplicationDbContext db;
        public CurtainsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Style");
        }
        public IActionResult Style()
        {
            var curtains = db.Curtains.Where(x => x.IsInStock == true).ToList();
            return View(curtains);
        }
        [HttpPost]
        public IActionResult Style(Guid curtainId)
        {
            var curtain = db.Curtains.Where(x => x.Id == curtainId).First();
            if (curtain.Equals(null))
            {
                return View("Error"); // TODO: create error view or something else 
            }
            var order = new Order(curtain.Name, curtain.Description, curtain.Pirce, curtain.CategoryId, curtain.Id);
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Fabric", order);
        }
        public IActionResult Fabric(Order order)
        {
            var curtain = db.Curtains.Where(c => c.Id == order.ProductId);
            return View(curtain);
        }
        [HttpPost]
        public IActionResult Fabric(Guid orderId, Guid materialId)
        {
            Order order = default;
            if (!orderId.Equals(default) && !materialId.Equals(default))
            {
                order = db.Orders.Where(o => o.Id == orderId).FirstOrDefault();
                if (!order.Equals(default))
                {
                    order.MaterialId = materialId;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Color", order);
        }
        public IActionResult Color(Order order)
        {
            return View(order);
        }
        [HttpPost]
        public IActionResult Color(Guid orderId, Guid colorId)
        {
            Order order = default;
            if (!orderId.Equals(default) && !colorId.Equals(default))
            {
                order = db.Orders.Where(o => o.Id == orderId).FirstOrDefault();
                if (!order.Equals(default))
                {
                    order.ColorId = colorId;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Color", order);
        }
        public IActionResult Size(Order order)
        {
            return View(order);
        }
        [HttpPost]
        public IActionResult Size()
        {
            return View(order);
        }
         */

    }
}