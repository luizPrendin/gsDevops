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
    public class TransacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transacaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transacaos.Include(t => t.MaterialReciclado).Include(t => t.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacaos
                .Include(t => t.MaterialReciclado)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacaos/Create
        public IActionResult Create()
        {
            ViewData["MaterialRecicladoId"] = new SelectList(_context.MaterialReciclados, "Id", "Tipo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Transacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataTransacao,Quantidade,Status,MaterialRecicladoId,UsuarioId")] Transacao transacao)
        {
           
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
            ViewData["MaterialRecicladoId"] = new SelectList(_context.MaterialReciclados, "Id", "Tipo", transacao.MaterialRecicladoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", transacao.UsuarioId);
            return View(transacao);
        }

        // GET: Transacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacaos.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["MaterialRecicladoId"] = new SelectList(_context.MaterialReciclados, "Id", "Tipo", transacao.MaterialRecicladoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", transacao.UsuarioId);
            return View(transacao);
        }

        // POST: Transacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataTransacao,Quantidade,Status,MaterialRecicladoId,UsuarioId")] Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["MaterialRecicladoId"] = new SelectList(_context.MaterialReciclados, "Id", "Tipo", transacao.MaterialRecicladoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", transacao.UsuarioId);
            return View(transacao);
        }

        // GET: Transacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacaos
                .Include(t => t.MaterialReciclado)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacao = await _context.Transacaos.FindAsync(id);
            if (transacao != null)
            {
                _context.Transacaos.Remove(transacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
            return _context.Transacaos.Any(e => e.Id == id);
        }
    }
}
