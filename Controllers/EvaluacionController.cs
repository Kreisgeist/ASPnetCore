using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_.NET_Core.Models;

namespace ASP_.NET_Core.Controllers
{
    public class EvaluacionController : Controller
    {
        private readonly EscuelaContext _context;

        public EvaluacionController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Evaluacion
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Evaluaciones.Include(e => e.Alumno).Include(e => e.Asignatura);
            return View(await escuelaContext.OrderBy(e => e.AlumnoId).ThenBy(e => e.AsignaturaId).ToListAsync());
        }

        // GET: Evaluacion/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluaciones
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluación == null)
            {
                return NotFound();
            }

            return View(evaluación);
        }

        // GET: Evaluacion/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Nombre");
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Nombre");
            return View();
        }

        // POST: Evaluacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoId,AsignaturaId,Nota,Nombre")] Evaluación evaluación)
        {
            if (ModelState.IsValid)
            {
                evaluación.Id = Guid.NewGuid().ToString();
                _context.Add(evaluación);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Nombre", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Nombre", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // GET: Evaluacion/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluaciones.FindAsync(id);
            if (evaluación == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Nombre", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Nombre", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // POST: Evaluacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AlumnoId,AsignaturaId,Nota,Id,Nombre")] Evaluación evaluación)
        {
            if (id != evaluación.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluación);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluaciónExists(evaluación.Id))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Nombre", evaluación.AlumnoId);
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Nombre", evaluación.AsignaturaId);
            return View(evaluación);
        }

        // GET: Evaluacion/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluación = await _context.Evaluaciones
                .Include(e => e.Alumno)
                .Include(e => e.Asignatura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluación == null)
            {
                return NotFound();
            }

            return View(evaluación);
        }

        // POST: Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var evaluación = await _context.Evaluaciones.FindAsync(id);
            _context.Evaluaciones.Remove(evaluación);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluaciónExists(string id)
        {
            return _context.Evaluaciones.Any(e => e.Id == id);
        }
    }
}
