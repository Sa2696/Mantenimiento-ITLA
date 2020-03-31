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
    public class AsignaturaProfesoresController : Controller
    {
        private readonly MyDbContext _context;

        public AsignaturaProfesoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AsignaturaProfesores
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.AsignaturaProfesores.Include(a => a.Asignatura).Include(a => a.Profesores);
            return View(await myDbContext.ToListAsync());
        }

        // GET: AsignaturaProfesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaProfesores = await _context.AsignaturaProfesores
                .Include(a => a.Asignatura)
                .Include(a => a.Profesores)
                .FirstOrDefaultAsync(m => m.asignaturaProfesoresID == id);
            if (asignaturaProfesores == null)
            {
                return NotFound();
            }

            return View(asignaturaProfesores);
        }

        // GET: AsignaturaProfesores/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre");
            ViewData["ProfesoresID"] = new SelectList(_context.Profesores, "ProfesoresID", "Apellido");
            return View();
        }

        // POST: AsignaturaProfesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("asignaturaProfesoresID,AsignaturaID,ProfesoresID")] AsignaturaProfesores asignaturaProfesores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaProfesores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaProfesores.AsignaturaID);
            ViewData["ProfesoresID"] = new SelectList(_context.Profesores, "ProfesoresID", "Apellido", asignaturaProfesores.ProfesoresID);
            return View(asignaturaProfesores);
        }

        // GET: AsignaturaProfesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaProfesores = await _context.AsignaturaProfesores.FindAsync(id);
            if (asignaturaProfesores == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaProfesores.AsignaturaID);
            ViewData["ProfesoresID"] = new SelectList(_context.Profesores, "ProfesoresID", "Apellido", asignaturaProfesores.ProfesoresID);
            return View(asignaturaProfesores);
        }

        // POST: AsignaturaProfesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("asignaturaProfesoresID,AsignaturaID,ProfesoresID")] AsignaturaProfesores asignaturaProfesores)
        {
            if (id != asignaturaProfesores.asignaturaProfesoresID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaProfesores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaProfesoresExists(asignaturaProfesores.asignaturaProfesoresID))
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
            ViewData["AsignaturaID"] = new SelectList(_context.Asignatura, "AsignaturaID", "Nombre", asignaturaProfesores.AsignaturaID);
            ViewData["ProfesoresID"] = new SelectList(_context.Profesores, "ProfesoresID", "Apellido", asignaturaProfesores.ProfesoresID);
            return View(asignaturaProfesores);
        }

        // GET: AsignaturaProfesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaProfesores = await _context.AsignaturaProfesores
                .Include(a => a.Asignatura)
                .Include(a => a.Profesores)
                .FirstOrDefaultAsync(m => m.asignaturaProfesoresID == id);
            if (asignaturaProfesores == null)
            {
                return NotFound();
            }

            return View(asignaturaProfesores);
        }

        // POST: AsignaturaProfesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturaProfesores = await _context.AsignaturaProfesores.FindAsync(id);
            _context.AsignaturaProfesores.Remove(asignaturaProfesores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaProfesoresExists(int id)
        {
            return _context.AsignaturaProfesores.Any(e => e.asignaturaProfesoresID == id);
        }
    }
}
