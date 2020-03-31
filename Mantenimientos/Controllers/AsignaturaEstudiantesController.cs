using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mantenimientos.Models;

namespace Mantenimientos.Controllers
{
    public class AsignaturaEstudiantesController : Controller
    {
        private readonly MyDbContext _context;

        public AsignaturaEstudiantesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AsignaturaEstudiantes
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.AsignaturaEstudiantes.Include(a => a.Asignatura).Include(a => a.Estudiantes);
            return View(await myDbContext.ToListAsync());
        }

        // GET: AsignaturaEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEstudiante = await _context.AsignaturaEstudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiantes)
                .FirstOrDefaultAsync(m => m.AsignaturaEstudianteID == id);
            if (asignaturaEstudiante == null)
            {
                return NotFound();
            }

            return View(asignaturaEstudiante);
        }

        // GET: AsignaturaEstudiantes/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre");
            ViewData["EstudiantesID"] = new SelectList(_context.Estudiantes, "EstudiantesID", "Apellido");
            return View();
        }

        // POST: AsignaturaEstudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignaturaEstudianteID,AsignaturaID,EstudiantesID")] AsignaturaEstudiante asignaturaEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaEstudiante.AsignaturaID);
            ViewData["EstudiantesID"] = new SelectList(_context.Estudiantes, "EstudiantesID", "Apellido", asignaturaEstudiante.EstudiantesID);
            return View(asignaturaEstudiante);
        }

        // GET: AsignaturaEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEstudiante = await _context.AsignaturaEstudiantes.FindAsync(id);
            if (asignaturaEstudiante == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaEstudiante.AsignaturaID);
            ViewData["EstudiantesID"] = new SelectList(_context.Estudiantes, "EstudiantesID", "Apellido", asignaturaEstudiante.EstudiantesID);
            return View(asignaturaEstudiante);
        }

        // POST: AsignaturaEstudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignaturaEstudianteID,AsignaturaID,EstudiantesID")] AsignaturaEstudiante asignaturaEstudiante)
        {
            if (id != asignaturaEstudiante.AsignaturaEstudianteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaEstudianteExists(asignaturaEstudiante.AsignaturaEstudianteID))
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
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaEstudiante.AsignaturaID);
            ViewData["EstudiantesID"] = new SelectList(_context.Estudiantes, "EstudiantesID", "Apellido", asignaturaEstudiante.EstudiantesID);
            return View(asignaturaEstudiante);
        }

        // GET: AsignaturaEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEstudiante = await _context.AsignaturaEstudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiantes)
                .FirstOrDefaultAsync(m => m.AsignaturaEstudianteID == id);
            if (asignaturaEstudiante == null)
            {
                return NotFound();
            }

            return View(asignaturaEstudiante);
        }

        // POST: AsignaturaEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturaEstudiante = await _context.AsignaturaEstudiantes.FindAsync(id);
            _context.AsignaturaEstudiantes.Remove(asignaturaEstudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaEstudianteExists(int id)
        {
            return _context.AsignaturaEstudiantes.Any(e => e.AsignaturaEstudianteID == id);
        }
    }
}
