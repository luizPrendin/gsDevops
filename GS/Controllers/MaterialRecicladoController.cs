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
    public class MaterialRecicladoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialRecicladoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaterialRecicladoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialReciclados.ToListAsync());
        }

        // GET: MaterialRecicladoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialReciclado = await _context.MaterialReciclados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialReciclado == null)
            {
                return NotFound();
            }

            return View(materialReciclado);
        }

        // GET: MaterialRecicladoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialRecicladoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Descricao,Quantidade,DataColeta,Origem")] MaterialReciclado materialReciclado)
        {
                _context.Add(materialReciclado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            return View(materialReciclado);
        }

        // GET: MaterialRecicladoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialReciclado = await _context.MaterialReciclados.FindAsync(id);
            if (materialReciclado == null)
            {
                return NotFound();
            }
            return View(materialReciclado);
        }

        // POST: MaterialRecicladoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Descricao,Quantidade,DataColeta,Origem")] MaterialReciclado materialReciclado)
        {
            if (id != materialReciclado.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(materialReciclado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialRecicladoExists(materialReciclado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            return View(materialReciclado);
        }

        // GET: MaterialRecicladoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialReciclado = await _context.MaterialReciclados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialReciclado == null)
            {
                return NotFound();
            }

            return View(materialReciclado);
        }

        // POST: MaterialRecicladoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialReciclado = await _context.MaterialReciclados.FindAsync(id);
            if (materialReciclado != null)
            {
                _context.MaterialReciclados.Remove(materialReciclado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialRecicladoExists(int id)
        {
            return _context.MaterialReciclados.Any(e => e.Id == id);
        }
    }
}
