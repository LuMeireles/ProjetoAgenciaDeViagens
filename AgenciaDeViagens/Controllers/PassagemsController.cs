using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViagens.Data;
using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Controllers
{
    public class PassagemsController : Controller
    {
        private readonly PassagemContext _context;

        public PassagemsController(PassagemContext context)
        {
            _context = context;
        }

        // GET: Passagems
        public async Task<IActionResult> Index()
        {
            var passagemContext = _context.Passagens.Include(p => p.Agencia).Include(p => p.Cliente);
            return View(await passagemContext.ToListAsync());
        }

        // GET: Passagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Agencia)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagems/Create
        public IActionResult Create()
        {
            ViewData["AgenciaCadastur"] = new SelectList(_context.Agencias, "Cadastur", "Endereco");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome"); //Página Home
            return View();
        }

        // POST: Passagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Destino,Preco,DataPartida,AgenciaCadastur,ClienteId")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgenciaCadastur"] = new SelectList(_context.Agencias, "Cadastur", "Endereco", passagem.AgenciaCadastur);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", passagem.ClienteId);
            return View(passagem);
        }

        // GET: Passagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            ViewData["AgenciaCadastur"] = new SelectList(_context.Agencias, "Cadastur", "Endereco", passagem.AgenciaCadastur);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", passagem.ClienteId);
            return View(passagem);
        }

        // POST: Passagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Destino,Preco,DataPartida,AgenciaCadastur,ClienteId")] Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id))
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
            ViewData["AgenciaCadastur"] = new SelectList(_context.Agencias, "Cadastur", "Endereco", passagem.AgenciaCadastur);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", passagem.ClienteId);
            return View(passagem);
        }

        // GET: Passagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Agencia)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.Passagens.FindAsync(id);
            _context.Passagens.Remove(passagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagens.Any(e => e.Id == id);
        }
    }
}
