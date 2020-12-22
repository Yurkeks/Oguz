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
    public class PillowsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public PillowsController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET
        public IActionResult Index()
        {
            var pillow = _context.Pillows.Include(m => m.Brand).Include(c => c.Colors).ToList();
            if (pillow == null || pillow.Count == 0)
                return RedirectToAction(nameof(Create));
            return View(pillow);
        }

        // GET
        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pillow pillow, IFormFile image)
        {
            if (image != null)
            {
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Pillows\\", image);
                pillow.ImageName = path.ToString();
            }
            if (ModelState.IsValid)
            {
                pillow.Id = Guid.NewGuid();
                //pillow.Category = Category.Pillows;
                //Size size = new Size
                //{
                //    Id = Guid.NewGuid(),
                //    Height = pillow.Size.Height,
                //    Width = pillow.Size.Width
                //};
                //_context.Add(pillow);
                //pillow.SizeId = size.Id;
                _context.Add(pillow);
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

            var pillow = await _context.Pillows.FindAsync(id);
            if (pillow == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", pillow.BrandId);
            return View(pillow);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pillow pillow, IFormFile image)
        {
            if (image != null)
            {
                string fileName = pillow.ImageName;
                string fullPath = _appEnvironment.ApplicationName + "\\Images\\Pillows\\" + pillow.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Pillows\\", image);
                pillow.ImageName = path.ToString();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pillow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PillowsExists(pillow.Id))
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
            return View(pillow);
        }

        public IActionResult Delete(Guid? id)
        {
            var pillow = _context.Pillows.Find(id);
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
            string PillowImagePath = _appEnvironment.ApplicationName + "\\Images\\Pillows\\" + pillow.ImageName;
            if (System.IO.File.Exists(PillowImagePath))
            {
                System.IO.File.Delete(PillowImagePath);
            }
            _context.Pillows.Remove(pillow);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PillowsExists(Guid id)
        {
            return _context.Pillows.Any(e => e.Id == id);
        }
    }
}
