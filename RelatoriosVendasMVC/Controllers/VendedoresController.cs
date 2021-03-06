using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelatoriosVendasMVC.Data;
using RelatoriosVendasMVC.Models;

namespace RelatoriosVendasMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly RelatoriosVendasMVCContext _context;

        public VendedoresController(RelatoriosVendasMVCContext context)
        {
            _context = context;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
            var relatoriosVendasMVCContext = _context.Vendedor.Include(v => v.Departamento);
            return View(await relatoriosVendasMVCContext.ToListAsync());
        }       
        

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "Id", "Nome");
            return View();
        }

        // POST: Vendedores/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,SalarioBase,Aniversario,DepartamentoId")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "Id", "Nome", vendedor.DepartamentoId);
            return View(vendedor);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "Id", "Nome", vendedor.DepartamentoId);
            return View(vendedor);
        }

        // POST: Vendedores/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,SalarioBase,Aniversario,DepartamentoId")] Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.Id))
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "Id", "Nome", vendedor.DepartamentoId);
            return View(vendedor);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .Include(v => v.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedor.Any(e => e.Id == id);
        }
    }
}
