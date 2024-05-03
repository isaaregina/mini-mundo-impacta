using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniMundo.Data;
using MiniMundo.Models;

namespace MiniMundo.Controllers
{
    public class VendasController : Controller
    {
        private readonly AppDBContext _context;

        public VendasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Venda.Include(v => v.Funcionario).Include(v => v.produto);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Funcionario)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.VendaID == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionario, "FuncionarioID", "CPF");
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaID,FuncionarioID,ProdutoID,venda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionario, "FuncionarioID", "CPF", venda.FuncionarioID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", venda.ProdutoID);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionario, "FuncionarioID", "CPF", venda.FuncionarioID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", venda.ProdutoID);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaID,FuncionarioID,ProdutoID,venda")] Venda venda)
        {
            if (id != venda.VendaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaID))
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
            ViewData["FuncionarioID"] = new SelectList(_context.Funcionario, "FuncionarioID", "CPF", venda.FuncionarioID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", venda.ProdutoID);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Funcionario)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.VendaID == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.VendaID == id);
        }
    }
}
