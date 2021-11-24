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
    public class CentroTrabajosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroTrabajosController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: CentroTrabajoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroTrabajos.Include(m => m.Municipio).ToListAsync());
        }

        
        // GET: CentroTrabajoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTrabajo = await _context.CentroTrabajos.
                Include(x => x.Provincia).
                Include(x => x.Municipio).
                FirstOrDefaultAsync(m => m.Id == id);

            if (centroTrabajo == null)
            {
                return NotFound();
            }

            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Create
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = new List<Municipio>();
            return View();
        }

        // POST: CentroTrabajoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,Nombre,Departamento,Direccion")]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create(CentroTrabajo centroTrabajo)
        {
            try
            {
                var m = await _context.CentroTrabajos.Where(x => x.Nombre == centroTrabajo.Nombre).FirstOrDefaultAsync();
                if (m is not null)
                    throw new NegocioException("Ya existe un centro de trabajo con este nombre");

                if (ModelState.IsValid)
                {
                    centroTrabajo.Creatat = DateTime.Now;
                    centroTrabajo.Modifiat = DateTime.Now;
                    _context.Add(centroTrabajo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
            }
            

            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == centroTrabajo.ProvinciaId).
                ToListAsync();

            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTrabajo = await _context.CentroTrabajos.FindAsync(id);
            if (centroTrabajo == null)
            {
                return NotFound();
            }
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == centroTrabajo.ProvinciaId).
                ToListAsync();

            return View(centroTrabajo);
        }

        // POST: CentroTrabajoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind("Id,Nombre,Departamento,Direccion")] 
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id,CentroTrabajo centroTrabajo)
        {
            if (id != centroTrabajo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    centroTrabajo.Modifiat = DateTime.Now;
                    _context.Update(centroTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroTrabajoExists(centroTrabajo.Id))
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

            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == centroTrabajo.ProvinciaId).
                ToListAsync();

            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*Include(x => x.Provincia).
                Include(x => x.Municipio).*/

            var centroTrabajo = await _context.CentroTrabajos.                
                FirstOrDefaultAsync(m => m.Id == id);

            if (centroTrabajo == null)
            {
                return NotFound();
            }

            var aspirantesCount = _context.Entry(centroTrabajo).
               Collection(b => b.Matriculas).
               Query().
               Count();


            if (aspirantesCount > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar el centro de trabajo {0} porque está asociado a {1} matrícula(s)", centroTrabajo.Nombre, aspirantesCount);
                ViewBag.hidden = true;
            }

            return View(centroTrabajo);
        }

        // POST: CentroTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroTrabajo = await _context.CentroTrabajos.FindAsync(id);
            _context.CentroTrabajos.Remove(centroTrabajo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroTrabajoExists(int id)
        {
            return _context.CentroTrabajos.Any(e => e.Id == id);
        }
    }
}
