﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRTask.Data;
using HRTask.Models;

namespace HRTask.Controllers
{
    public class ScreensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Screens
        public async Task<IActionResult> Index()
        {
              return View(await _context.Screens.ToListAsync());
        }

        // GET: Screens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Screens == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }

        // GET: Screens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Screens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screen);
        }

        // GET: Screens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Screens == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }
            return View(screen);
        }

        // POST: Screens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Screen screen)
        {
            if (id != screen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenExists(screen.Id))
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
            return View(screen);
        }

        // GET: Screens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Screens == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }

        // POST: Screens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Screens == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Screens'  is null.");
            }
            var screen = await _context.Screens.FindAsync(id);
            if (screen != null)
            {
                _context.Screens.Remove(screen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenExists(int id)
        {
          return _context.Screens.Any(e => e.Id == id);
        }
    }
}
