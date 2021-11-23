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
    [Authorize(Roles = "Especialista")]
    public class CentroTrabajosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroTrabajosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
        // GET: CentroTrabajoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroTrabajos.Include(m => m.Municipio).ToListAsync());
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
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
        public async Task<IActionResult> Create(CentroTrabajo centroTrabajo)
        {
            if (ModelState.IsValid)
            {
                centroTrabajo.Creatat = DateTime.Now;
                centroTrabajo.Modifiat = DateTime.Now;
                _context.Add(centroTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == centroTrabajo.ProvinciaId).
                ToListAsync();

            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Edit/5
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

            return View(centroTrabajo);
        }

        // POST: CentroTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
