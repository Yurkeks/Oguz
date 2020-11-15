using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public OrdersController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Section));
        }

        public IActionResult Section()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (id == null)
                return NotFound();
            if (order == null)
                return NotFound();

            return View(order);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(order);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(order.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(order);
        //}

        //public IActionResult Delete(Guid? id)
        //{
        //    var order = _context.Orders.Find(id);
        //    var sizes = _context.Sizes.Where(c => c.OrderId == id);

        //    _context.Sizes.RemoveRange(sizes);
        //    _context.Orders.Remove(order);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool OrderExists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
