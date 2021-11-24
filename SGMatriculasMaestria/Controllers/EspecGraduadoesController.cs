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
    public class EspecGraduadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecGraduadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: EspecGraduadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspecGraduados.ToListAsync());
        }

        
        // GET: EspecGraduadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especGraduado = await _context.EspecGraduados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especGraduado == null)
            {
                return NotFound();
            }

            return View(especGraduado);
        }

        // GET: EspecGraduadoes/Create
        [Authorize(Roles = "Especialista")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspecGraduadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EspecGraduado especGraduado)
        {
            if (ModelState.IsValid)
            {
                especGraduado.Creatat = DateTime.Now;
                especGraduado.Modifiat = DateTime.Now;
                _context.Add(especGraduado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especGraduado);
        }

        // GET: EspecGraduadoes/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especGraduado = await _context.EspecGraduados.FindAsync(id);
            if (especGraduado == null)
            {
                return NotFound();
            }
            return View(especGraduado);
        }

        // POST: EspecGraduadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EspecGraduado especGraduado)
        {
            if (id != especGraduado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    especGraduado.Modifiat = DateTime.Now;
                    _context.Update(especGraduado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecGraduadoExists(especGraduado.Id))
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
            return View(especGraduado);
        }

        // GET: EspecGraduadoes/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especGraduado = await _context.EspecGraduados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especGraduado == null)
            {
                return NotFound();
            }

            return View(especGraduado);
        }

        // POST: EspecGraduadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especGraduado = await _context.EspecGraduados.FindAsync(id);
            _context.EspecGraduados.Remove(especGraduado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecGraduadoExists(int id)
        {
            return _context.EspecGraduados.Any(e => e.Id == id);
        }
    }
}
