using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.Controllers
{
    public class SMTPClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SMTPClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SMTPClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.SMTPClients.ToListAsync());
        }

        // GET: SMTPClients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMTPClient = await _context.SMTPClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sMTPClient == null)
            {
                return NotFound();
            }

            return View(sMTPClient);
        }

        // GET: SMTPClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SMTPClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Port,Email,Password,Host,Id,Name,Active")] SMTPClient sMTPClient)
        {
            if (ModelState.IsValid)
            {
                sMTPClient.Id = Guid.NewGuid();
                _context.Add(sMTPClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sMTPClient);
        }

        // GET: SMTPClients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMTPClient = await _context.SMTPClients.FindAsync(id);
            if (sMTPClient == null)
            {
                return NotFound();
            }
            return View(sMTPClient);
        }

        // POST: SMTPClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Port,Email,Password,Host,Id,Name,Active")] SMTPClient sMTPClient)
        {
            if (id != sMTPClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sMTPClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SMTPClientExists(sMTPClient.Id))
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
            return View(sMTPClient);
        }

        // GET: SMTPClients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var sMTPClient = await _context.SMTPClients.FindAsync(id);
            _context.SMTPClients.Remove(sMTPClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMTPClientExists(Guid id)
        {
            return _context.SMTPClients.Any(e => e.Id == id);
        }
    }
}
