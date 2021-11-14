using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Controllers
{
    [Authorize]
    public class MatriculasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatriculasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matricula.Include(x=>x.Aspirante).ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewBag.Facultades = _context.Facultades.ToList();
            ViewBag.CategoriasDocentes = _context.CategDocentes.ToList();
            ViewBag.SecretarioPost = _context.SecretarioPostgrados.ToList();
            ViewBag.CentrosTrabajo = _context.CentroTrabajos.ToList();
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            matricula.Maestria = _context.Maestrias.Where(x => x.Id == matricula.Maestria.Id).Include(x => x.Facultad).FirstOrDefault();
            matricula.CategDocente = _context.CategDocentes.Where(x => x.Id == matricula.CategDocente.Id).FirstOrDefault();
            matricula.CentroTrabajo = _context.CentroTrabajos.Where(x => x.Id == matricula.CentroTrabajo.Id).FirstOrDefault();
            matricula.SecretarioPostg = _context.SecretarioPostgrados.Where(x => x.Id == matricula.SecretarioPostg.Id).FirstOrDefault();
            
                var aspirante =await _context.Aspirantes.FindAsync(matricula.Aspirante.CI);
                if (aspirante is not null)
                {
                    matricula.Aspirante = aspirante;
                    _context.Add(matricula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("no user", "no existe el usuario");
                
            
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Facultades = _context.Facultades.ToList();
            ViewBag.CategoriasDocentes = _context.CategDocentes.ToList();
            ViewBag.SecretarioPost = _context.SecretarioPostgrados.ToList();
            ViewBag.CentrosTrabajo = _context.CentroTrabajos.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicio,FechaCulminacion,MotivoSolicitud,AnnoExperienciaLaboral,FechaMatricula")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
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
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matricula.FindAsync(id);
            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matricula.Any(e => e.Id == id);
        }
    }
}
