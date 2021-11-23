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
    public class CategDocentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategDocentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategDocentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategDocentes.ToListAsync());
        }

        // GET: CategDocentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categDocente = await _context.CategDocentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categDocente == null)
            {
                return NotFound();
            }

            return View(categDocente);
        }

        // GET: CategDocentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategDocentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] CategDocente categDocente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cat = _context.CategDocentes.Where(x => x.Nombre == categDocente.Nombre).FirstOrDefault();
                    if (cat is not null)
                        throw new NegocioException("Ya existe una categoría con estas características");

                    categDocente.Creatat = DateTime.Now;
                    categDocente.Modifiat = DateTime.Now;
                    _context.Add(categDocente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }catch(NegocioException nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
            
            return View(categDocente);
        }

        // GET: CategDocentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categDocente = await _context.CategDocentes.FindAsync(id);
            if (categDocente == null)
            {
                return NotFound();
            }
            return View(categDocente);
        }

        // POST: CategDocentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CategDocente categDocente)
        {
            if (id != categDocente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categDocente.Modifiat = DateTime.Now;
                    _context.Update(categDocente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategDocenteExists(categDocente.Id))
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
            return View(categDocente);
        }

        // GET: CategDocentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categDocente = await _context.CategDocentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categDocente == null)
            {
                return NotFound();
            }

            return View(categDocente);
        }

        // POST: CategDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categDocente = await _context.CategDocentes.FindAsync(id);
            _context.CategDocentes.Remove(categDocente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategDocenteExists(int id)
        {
            return _context.CategDocentes.Any(e => e.Id == id);
        }
    }
}
