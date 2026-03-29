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
    public class WypozyczenieController : Controller
    {
        private readonly Biblioteka _context;

        public WypozyczenieController(Biblioteka context)
        {
            _context = context;
        }

        // GET: Wypozyczenie
        public async Task<IActionResult> Index()
        {
            var biblioteka = _context.Wypozyczenia.Include(w => w.czytelnik).Include(w => w.ksiazka);
            return View(await biblioteka.ToListAsync());
        }

        // GET: Wypozyczenie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wypozyczenie = await _context.Wypozyczenia
                .Include(w => w.czytelnik)
                .Include(w => w.ksiazka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wypozyczenie == null)
            {
                return NotFound();
            }

            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Create
        public IActionResult Create()
        {
            ViewData["czytelnikID"] = new SelectList(_context.Czytelnicy, "Id", "Imie");
            ViewData["ksiazkaID"] = new SelectList(_context.Ksiazki, "Id", "Tytul");
            return View();
        }

        // POST: Wypozyczenie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,czytelnikID,ksiazkaID,DataWypozyczenia,DataZwrotu")] Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wypozyczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["czytelnikID"] = new SelectList(_context.Czytelnicy, "Id", "Imie", wypozyczenie.czytelnikID);
            ViewData["ksiazkaID"] = new SelectList(_context.Ksiazki, "Id", "Tytul", wypozyczenie.ksiazkaID);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie == null)
            {
                return NotFound();
            }
            ViewData["czytelnikID"] = new SelectList(_context.Czytelnicy, "Id", "Imie", wypozyczenie.czytelnikID);
            ViewData["ksiazkaID"] = new SelectList(_context.Ksiazki, "Id", "Tytul", wypozyczenie.ksiazkaID);
            return View(wypozyczenie);
        }

        // POST: Wypozyczenie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,czytelnikID,ksiazkaID,DataWypozyczenia,DataZwrotu")] Wypozyczenie wypozyczenie)
        {
            if (id != wypozyczenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wypozyczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WypozyczenieExists(wypozyczenie.Id))
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
            ViewData["czytelnikID"] = new SelectList(_context.Czytelnicy, "Id", "Imie", wypozyczenie.czytelnikID);
            ViewData["ksiazkaID"] = new SelectList(_context.Ksiazki, "Id", "Tytul", wypozyczenie.ksiazkaID);
            return View(wypozyczenie);
        }

        // GET: Wypozyczenie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wypozyczenie = await _context.Wypozyczenia
                .Include(w => w.czytelnik)
                .Include(w => w.ksiazka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wypozyczenie == null)
            {
                return NotFound();
            }

            return View(wypozyczenie);
        }

        // POST: Wypozyczenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie != null)
            {
                _context.Wypozyczenia.Remove(wypozyczenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WypozyczenieExists(int id)
        {
            return _context.Wypozyczenia.Any(e => e.Id == id);
        }
    }
}
