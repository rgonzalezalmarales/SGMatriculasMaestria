using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Controllers
{
    public class CentroTrabajoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroTrabajoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CentroTrabajoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroTrabajos.ToListAsync());
        }

        // GET: CentroTrabajoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTrabajo = await _context.CentroTrabajos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroTrabajo == null)
            {
                return NotFound();
            }

            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroTrabajoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Departamento,Direccion")] CentroTrabajo centroTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(centroTrabajo);
        }

        // POST: CentroTrabajoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Departamento,Direccion")] CentroTrabajo centroTrabajo)
        {
            if (id != centroTrabajo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(centroTrabajo);
        }

        // GET: CentroTrabajoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroTrabajo = await _context.CentroTrabajos
                .FirstOrDefaultAsync(m => m.Id == id);
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
