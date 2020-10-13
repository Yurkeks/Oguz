using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;

namespace Oguz.Controllers
{
    public class ClientsController : Controller
    {

        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;

        public ClientsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index() => RedirectToAction(nameof(Section));

        public IActionResult Section() => View();

        public async Task<IActionResult> Edit(Guid? id)
        {
            var order = await _userManager.FindByIdAsync(id.ToString());
            if (id == null)
                return NotFound();
            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.ApplicationUsers.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(Guid? id)
        {
            var order = _context.Orders.Find(id);
            var sizes = _context.Sizes.Where(c => c.OrderId == id);

            _context.Sizes.RemoveRange(sizes);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}
