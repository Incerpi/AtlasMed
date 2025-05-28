using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtlasMed_GS.Models;
using AtlasMed_GS.Persistence;

namespace AtlasMed_GS.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly DatabaseContext _context;

        public ConsultasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Consulta.Include(c => c.Hospital).Include(c => c.Medico).Include(c => c.Paciente).Include(c => c.Prontuario).Include(c => c.Medicacao);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Hospital)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .Include(c => c.Prontuario)
                .Include(c => c.Medicacao)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            // Pacientes
            var pacientes = _context.Paciente.ToList();
            ViewBag.NomePaciente = new SelectList(pacientes, "IdPaciente", "Nome");
            ViewBag.CpfPaciente = new SelectList(pacientes, "IdPaciente", "Cpf");

            // Médicos
            var medicos = _context.Medico.ToList();
            ViewBag.NomeMedico = new SelectList(medicos, "IdMedico", "Nome");
            ViewBag.CrmMedico = new SelectList(medicos, "IdMedico", "Crm");

            // Prontuários
            var prontuarios = _context.Prontuario.ToList();
            ViewBag.SintomasProntuario = new SelectList(prontuarios, "IdProntuario", "Sintomas");
            ViewBag.AlergiasProntuario = new SelectList(prontuarios, "IdProntuario", "Alergias");
            ViewBag.TipoSanguineo = new SelectList(prontuarios, "IdProntuario", "TipoSanguineo");
            ViewBag.HorarioProntuario = new SelectList(prontuarios, "IdProntuario", "HorarioChegada");

            // Medicações
            ViewBag.Medicacao = new SelectList(_context.Medicacao, "IdMedicacao", "Nome");

            // Hospitais
            ViewBag.Hospital = new SelectList(_context.Hospital, "IdHospital", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,IdPaciente,IdMedico,IdProntuario,IdHospital,IdMedicacao,HorarioConsulta,Diagnostico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarregar ViewBags em caso de erro de validação
            var pacientes = _context.Paciente.ToList();
            ViewBag.NomePaciente = new SelectList(pacientes, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewBag.CpfPaciente = new SelectList(pacientes, "IdPaciente", "Cpf", consulta.IdPaciente);

            var medicos = _context.Medico.ToList();
            ViewBag.NomeMedico = new SelectList(medicos, "IdMedico", "Nome", consulta.IdMedico);
            ViewBag.CrmMedico = new SelectList(medicos, "IdMedico", "Crm", consulta.IdMedico);

            var prontuarios = _context.Prontuario.ToList();
            ViewBag.SintomasProntuario = new SelectList(prontuarios, "IdProntuario", "Sintomas", consulta.IdProntuario);
            ViewBag.AlergiasProntuario = new SelectList(prontuarios, "IdProntuario", "Alergias", consulta.IdProntuario);
            ViewBag.TipoSanguineo = new SelectList(prontuarios, "IdProntuario", "TipoSanguineo", consulta.IdProntuario);
            ViewBag.HorarioProntuario = new SelectList(prontuarios, "IdProntuario", "HorarioChegada", consulta.IdProntuario);

            ViewBag.Medicacao = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", consulta.IdMedicacao);
            ViewBag.Hospital = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);

            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Crm", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Cpf", consulta.IdPaciente);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Sintomas", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Alergias", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "TipoSanguineo", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "HorarioChegada", consulta.IdProntuario);
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", consulta.IdMedicacao);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,IdPaciente,IdMedico,IdProntuario,IdHospital,IdMedicacao,HorarioConsulta,Diagnostico")] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.IdConsulta))
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
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Crm", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Cpf", consulta.IdPaciente);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Sintomas", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Alergias", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "TipoSanguineo", consulta.IdProntuario);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "HorarioChegada", consulta.IdProntuario);
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", consulta.IdMedicacao);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Hospital)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .Include(c => c.Prontuario)
                .Include(c => c.Medicacao)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'DatabaseContext.Consulta'  is null.");
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return (_context.Consulta?.Any(e => e.IdConsulta == id)).GetValueOrDefault();
        }
    }
}
