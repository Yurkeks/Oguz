using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oguz.Areas;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class StylesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _appEnvironment;
        public StylesController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Styles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Styles.ToListAsync());
        }

        // GET: Styles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _context.Styles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // GET: Styles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Styles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Style style, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Styles\\", image);
                    style.ImageName = path.ToString();
                }
                style.Id = new Guid();
                _context.Add(style);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Styles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _context.Styles.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        // POST: Styles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Style style, IFormFile image)
        {
            if (image != null)
            {
                string fileName = style.ImageName;
                string fullPath = _appEnvironment.ApplicationName + "\\Images\\Curtains\\" + style.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var path = FilesHelper.UploadFile(_appEnvironment.WebRootPath + "\\Images\\Curtains\\", image);
                style.ImageName = path.ToString();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(style);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StyleExists(style.Id))
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
            return View(style);
        }

        // GET: Styles/Delete/5
        public IActionResult Delete(Guid? id)
        {
            var style = _context.Styles.Find(id);
            string MaterialImagePath = _appEnvironment.ApplicationName + "\\Images\\Styles\\" + style.ImageName;
            if (System.IO.File.Exists(MaterialImagePath))
            {
                System.IO.File.Delete(MaterialImagePath);
            }
            _context.Styles.Remove(style);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StyleExists(Guid id)
        {
            return _context.Styles.Any(e => e.Id == id);
        }
    }
}
