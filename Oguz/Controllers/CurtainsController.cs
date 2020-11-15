using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Areas;
using Oguz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Oguz.Controllers
{
    public class CurtainsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public CurtainsController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET
        public IActionResult Index()
        {
            var curtains = _context.Curtains.Include(c => c.Colors).Include(m => m.Brand).ToList();
            if (curtains == null || curtains.Count == 0)
                return RedirectToAction(nameof(Create));
            return View(curtains);
        }

        // GET
        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curtains curtains, IFormFile image)
        {
            if (image != null)
            {
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Curtains\\", image);
                curtains.ImageName = path.ToString();
            }
            if (ModelState.IsValid)
            {
                curtains.Id = Guid.NewGuid();
                _context.Add(curtains);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        // GET
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtains = await _context.Curtains.FindAsync(id);
            if (curtains == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", curtains.BrandId);
            return View(curtains);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Curtains curtains, IFormFile image)
        {
            if (image != null)
            {
                string fileName = curtains.ImageName;
                string fullPath = _appEnvironment.ApplicationName + "\\Images\\Curtains\\" + curtains.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Curtains\\", image);
                curtains.ImageName = path.ToString();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curtains);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurtainsExists(curtains.Id))
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
            return View(curtains);
        }

        // GET
        public IActionResult Delete(Guid? id)
        {
            var curtains = _context.Curtains.Find(id);
            var colors = _context.Colors.Where(c => c.ProductId == id);
            _context.Colors.RemoveRange(colors);
            foreach (var item in colors)
            {
                string ColorImagePath = _appEnvironment.ApplicationName + "\\Images\\Colors\\" + item.ImageName;
                if (System.IO.File.Exists(ColorImagePath))
                {
                    System.IO.File.Delete(ColorImagePath);
                }
            }
            string CurtainsImagePath = _appEnvironment.ApplicationName + "\\Images\\Curtains\\" + curtains.ImageName;
            if (System.IO.File.Exists(CurtainsImagePath))
            {
                System.IO.File.Delete(CurtainsImagePath);
            }
            _context.Curtains.Remove(curtains);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CurtainsExists(Guid id)
        {
            return _context.Curtains.Any(e => e.Id == id);
        }
    }
}
