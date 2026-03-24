using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wprawka1.Data;
using Wprawka1.Models;

namespace Wprawka1.Controllers
{
    public class WydawcaController : Controller
    {
        private readonly Biblioteka _context;

        public WydawcaController(Biblioteka context)
        {
            _context = context;
        }

        // GET: Wydawca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wydawcy.ToListAsync());
        }

        // GET: Wydawca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawca = await _context.Wydawcy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydawca == null)
            {
                return NotFound();
            }

            return View(wydawca);
        }

        // GET: Wydawca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wydawca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Wydawca wydawca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydawca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wydawca);
        }

        // GET: Wydawca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawca = await _context.Wydawcy.FindAsync(id);
            if (wydawca == null)
            {
                return NotFound();
            }
            return View(wydawca);
        }

        // POST: Wydawca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Wydawca wydawca)
        {
            if (id != wydawca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydawca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydawcaExists(wydawca.Id))
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
            return View(wydawca);
        }

        // GET: Wydawca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wydawca = await _context.Wydawcy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydawca == null)
            {
                return NotFound();
            }

            return View(wydawca);
        }

        // POST: Wydawca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wydawca = await _context.Wydawcy.FindAsync(id);
            if (wydawca != null)
            {
                _context.Wydawcy.Remove(wydawca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydawcaExists(int id)
        {
            return _context.Wydawcy.Any(e => e.Id == id);
        }
    }
}
