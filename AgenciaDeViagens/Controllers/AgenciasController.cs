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
    public class AgenciasController : Controller
    {
        private readonly PassagemContext _context;

        public AgenciasController(PassagemContext context)
        {
            _context = context;
        }

        // GET: Agencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agencias.ToListAsync());
        }

        // GET: Agencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencias
                .FirstOrDefaultAsync(m => m.Cadastur == id);
            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // GET: Agencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cadastur,Nome,Telefone,Endereco,GuiaTuristico")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agencia);
        }

        // GET: Agencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencias.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cadastur,Nome,Telefone,Endereco,GuiaTuristico")] Agencia agencia)
        {
            if (id != agencia.Cadastur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaExists(agencia.Cadastur))
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
            return View(agencia);
        }

        // GET: Agencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencia = await _context.Agencias
                .FirstOrDefaultAsync(m => m.Cadastur == id);
            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        // POST: Agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);
            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaExists(int id)
        {
            return _context.Agencias.Any(e => e.Cadastur == id);
        }
    }
}
