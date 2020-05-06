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

    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public ColorsController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET
        public IActionResult Index(Guid id)
        {
            var colors = _context.Colors.Where(c => c.MaterialId == id).ToList();
            if (colors == null || colors.Count == 0)
                return RedirectToAction("Create", "Colors", new { materialId = id });

            var category = _context.Materials.Find(id).Category;
            if (category == Category.Accessories)
                ViewBag.BackUrl = "/Accessories/";
            if (category == Category.Shades)
                ViewBag.BackUrl = "/Curtains/";
            if (category == Category.Pillows)
                ViewBag.BackUrl = "/Pillows/";
            if (category == Category.Curtains)
                ViewBag.BackUrl = "/Curtains/";
            ViewBag.Category = category.ToString();
            return View(colors);
        }

        // GET
        public IActionResult Create(Guid materialId)
        {
            Color color = new Color()
            {
                Id = Guid.NewGuid(),
                MaterialId = materialId
            };
            return View(color);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color, IFormFile image)
        {
            if (image != null)
            {
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Colors\\", image);
                color.ImageName = path.ToString();
            }
            if (ModelState.IsValid)
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Colors", new { id = color.MaterialId });
        }


        // GET
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Color color, IFormFile image)
        {
            if (image != null)
            {
                string fileName = color.ImageName;
                string fullPath = _appEnvironment.ApplicationName + "\\Images\\Colors\\" + color.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Colors\\", image);
                color.ImageName = path.ToString();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(color);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(color.Id))
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
            return View(color);
        }

        public IActionResult Delete(Guid? id)
        {
            var color = _context.Colors.Find(id);
            string ImagePath = _appEnvironment.ApplicationName + "\\Images\\Curtains\\" + color.ImageName;
            if (System.IO.File.Exists(ImagePath))
            {
                System.IO.File.Delete(ImagePath);
            }
            _context.Colors.Remove(color);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorExists(Guid id)
        {
            return _context.Colors.Any(e => e.Id == id);
        }
    }
}
