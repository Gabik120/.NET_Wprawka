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
    public class CzytelnikController : Controller
    {
        private readonly Biblioteka _context;

        public CzytelnikController(Biblioteka context)
        {
            _context = context;
        }

        // GET: Czytelnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Czytelnicy.ToListAsync());
        }

        // GET: Czytelnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // GET: Czytelnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Czytelnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,KartaBiblioteczna")] Czytelnik czytelnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(czytelnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(czytelnik);
        }

        // GET: Czytelnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy.FindAsync(id);
            if (czytelnik == null)
            {
                return NotFound();
            }
            return View(czytelnik);
        }

        // POST: Czytelnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,KartaBiblioteczna")] Czytelnik czytelnik)
        {
            if (id != czytelnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czytelnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzytelnikExists(czytelnik.Id))
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
            return View(czytelnik);
        }

        // GET: Czytelnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnicy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // POST: Czytelnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var czytelnik = await _context.Czytelnicy.FindAsync(id);
            if (czytelnik != null)
            {
                _context.Czytelnicy.Remove(czytelnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzytelnikExists(int id)
        {
            return _context.Czytelnicy.Any(e => e.Id == id);
        }
    }
}
