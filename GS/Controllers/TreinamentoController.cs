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
    public class TreinamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreinamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treinamentoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Treinamentos.Include(t => t.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Treinamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinamento = await _context.Treinamentos
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinamento == null)
            {
                return NotFound();
            }

            return View(treinamento);
        }

        // GET: Treinamentoes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Treinamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,DataInicio,DataTransacao,UsuarioId")] Treinamento treinamento)
        {
                _context.Add(treinamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", treinamento.UsuarioId);
            return View(treinamento);
        }

        // GET: Treinamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinamento = await _context.Treinamentos.FindAsync(id);
            if (treinamento == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", treinamento.UsuarioId);
            return View(treinamento);
        }

        // POST: Treinamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,DataInicio,DataTransacao,UsuarioId")] Treinamento treinamento)
        {
            if (id != treinamento.Id)
            {
                return NotFound();
            }

         
                try
                {
                    _context.Update(treinamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinamentoExists(treinamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", treinamento.UsuarioId);
            return View(treinamento);
        }

        // GET: Treinamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinamento = await _context.Treinamentos
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinamento == null)
            {
                return NotFound();
            }

            return View(treinamento);
        }

        // POST: Treinamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinamento = await _context.Treinamentos.FindAsync(id);
            if (treinamento != null)
            {
                _context.Treinamentos.Remove(treinamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinamentoExists(int id)
        {
            return _context.Treinamentos.Any(e => e.Id == id);
        }
    }
}
