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
    public class AccessoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public AccessoriesController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET
        public IActionResult Index()
        {
            var materials = _context.Materials.Where(p => p.Category == Category.Accessories).Include(m => m.Brand).Include(c => c.Colors).ToList();
            if (materials == null || materials.Count == 0)
                return RedirectToAction(nameof(Create));
            return View(materials);
        }

        // GET
        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material, IFormFile image)
        {
            if (image != null)
            {
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Accessories\\", image);
                material.ImageName = path.ToString();
            }
            if (ModelState.IsValid)
            {
                material.Id = Guid.NewGuid();
                material.Category = Category.Accessories;
                Size size = new Size
                {
                    Id = Guid.NewGuid(),
                    Height = material.Size.Height,
                    Width = material.Size.Width
                };
                _context.Add(size);
                material.SizeId = size.Id;
                _context.Add(material);
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

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", material.BrandId);
            return View(material);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Material material, IFormFile image)
        {
            if (image != null)
            {
                string fileName = material.ImageName;
                string fullPath = _appEnvironment.ApplicationName + "\\Images\\Accessories\\" + material.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Accessories\\", image);
                material.ImageName = path.ToString();
            }

            material.Category = Category.Accessories;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            return View(material);
        }

        // GET
        public IActionResult Delete(Guid? id)
        {
            var material = _context.Materials.Find(id);
            var colors = _context.Colors.Where(c => c.MaterialId == id);
            _context.Colors.RemoveRange(colors);
            foreach (var item in colors)
            {
                string ColorImagePath = _appEnvironment.ApplicationName + "\\Images\\Colors\\" + item.ImageName;
                if (System.IO.File.Exists(ColorImagePath))
                {
                    System.IO.File.Delete(ColorImagePath);
                }
            }
            string MaterialImagePath = _appEnvironment.ApplicationName + "\\Images\\Accessories\\" + material.ImageName;
            if (System.IO.File.Exists(MaterialImagePath))
            {
                System.IO.File.Delete(MaterialImagePath);
            }
            _context.Materials.Remove(material);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(Guid id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
