﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtlasMed_GS.Models;
using AtlasMed_GS.Persistence;

namespace AtlasMed_GS.Controllers
{
    public class Medicos1Controller : Controller
    {
        private readonly DatabaseContext _context;

        public Medicos1Controller(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Medicos1
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Medico.Include(m => m.Hospital);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Medicos1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Hospital)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medicos1/Create
        public IActionResult Create()
        {
            ViewBag.IdHospital = new SelectList(_context.Hospital, "IdHospital", "Nome");
            return View();
        }

        // POST: Medicos1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Cpf,Crm,UfCrm,Especialidade,IdHospital")] Medico medico)
        {
            ModelState.Remove("Hospital"); // 👈 Remover validação do campo de navegação
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdHospital = new SelectList(_context.Hospital, "IdHospital", "Nome", medico.IdHospital);
            return View(medico);
        }

        // GET: Medicos1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", medico.IdHospital);
            return View(medico);
        }

        // POST: Medicos1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nome,Cpf,Crm,UfCrm,Especialidade,IdHospital")] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            ModelState.Remove("Hospital");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
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
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", medico.IdHospital);
            return View(medico);
        }

        // GET: Medicos1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Hospital)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medicos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medico == null)
            {
                return Problem("Entity set 'DatabaseContext.Medico'  is null.");
            }
            var medico = await _context.Medico.FindAsync(id);
            if (medico != null)
            {
                _context.Medico.Remove(medico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medico?.Any(e => e.IdMedico == id)).GetValueOrDefault();
        }
    }
}
