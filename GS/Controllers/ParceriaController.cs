using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GS.Data;
using GS.Models;

namespace GS.Controllers
{
    public class ParceriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParceriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parceria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parcerias.ToListAsync());
        }

        // GET: Parceria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parcerias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parceria == null)
            {
                return NotFound();
            }

            return View(parceria);
        }

        // GET: Parcerias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parcerias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Descricao")] Parceria parceria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parceria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parceria);
        }

        // GET: Parcerias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parcerias.FindAsync(id);
            if (parceria == null)
            {
                return NotFound();
            }
            return View(parceria);
        }

        // POST: Parcerias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,Descricao")] Parceria parceria)
        {
            if (id != parceria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parceria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceriaExists(parceria.Id))
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
            return View(parceria);
        }

        // GET: Parcerias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parcerias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parceria == null)
            {
                return NotFound();
            }

            return View(parceria);
        }

        // POST: Parcerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parceria = await _context.Parcerias.FindAsync(id);
            if (parceria != null)
            {
                _context.Parcerias.Remove(parceria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParceriaExists(int id)
        {
            return _context.Parcerias.Any(e => e.Id == id);
        }
    }
}
