using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Exceptions;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Controllers
{
    [Authorize]
    public class FacultadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: Facultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facultades.ToListAsync());
        }
        
        // GET: Facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultad = await _context.Facultades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultad == null)
            {
                return NotFound();
            }

            return View(facultad);
        }

        // GET: Facultades/Create
        [Authorize(Roles = "Especialista")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Facultad facultad)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.Facultades.Where(x => x.Nombre == facultad.Nombre).FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe una facultad con este nombre");

                    facultad.Creatat = DateTime.Now;
                    facultad.Modifiat = DateTime.Now;
                    _context.Add(facultad);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (NegocioException nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
            }
            catch (Exception exp)
            {
                BadRequest(exp);
            }



            if (ModelState.IsValid)
            {
                
            }
            return View(facultad);
        }

        // GET: Facultades/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultad = await _context.Facultades.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }
            return View(facultad);
        }

        // POST: Facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Facultad facultad)
        {
            if (id != facultad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facultad.Modifiat = DateTime.Now;
                    _context.Update(facultad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultadExists(facultad.Id))
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
            return View(facultad);
        }

        // GET: Facultades/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultad = await _context.Facultades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultad == null)
            {
                return NotFound();
            }

            var count = _context.Entry(facultad).
               Collection(b => b.Maestrias).
               Query().
               Count();


            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar la facultad {0} porque está asociada a {1} matrícula(s)", facultad.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(facultad);
        }

        // POST: Facultades/Delete/5
        [Authorize(Roles = "Especialista")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultad = await _context.Facultades.FindAsync(id);
            _context.Facultades.Remove(facultad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultadExists(int id)
        {
            return _context.Facultades.Any(e => e.Id == id);
        }
    }
}
