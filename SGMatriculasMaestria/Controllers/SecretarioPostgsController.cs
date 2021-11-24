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
    public class SecretarioPostgsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SecretarioPostgsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: SecretarioPostgs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SecretarioPostgrados.ToListAsync());
        }

        
        // GET: SecretarioPostgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretarioPostg = await _context.SecretarioPostgrados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secretarioPostg == null)
            {
                return NotFound();
            }

            return View(secretarioPostg);
        }

        // GET: SecretarioPostgs/Create
        [Authorize(Roles = "Especialista")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SecretarioPostgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] SecretarioPostg secretarioPostg)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.SecretarioPostgrados.Where(x => x.Nombre == secretarioPostg.Nombre).FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe un se cretario con este nombre");
                    
                    secretarioPostg.Creatat = DateTime.Now;
                    secretarioPostg.Modifiat = DateTime.Now;
                    _context.Add(secretarioPostg);
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
            return View(secretarioPostg);
        }

        // GET: SecretarioPostgs/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretarioPostg = await _context.SecretarioPostgrados.FindAsync(id);
            if (secretarioPostg == null)
            {
                return NotFound();
            }
            return View(secretarioPostg);
        }

        // POST: SecretarioPostgs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] SecretarioPostg secretarioPostg)
        {
            if (id != secretarioPostg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secretarioPostg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecretarioPostgExists(secretarioPostg.Id))
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
            return View(secretarioPostg);
        }

        // GET: SecretarioPostgs/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretarioPostg = await _context.SecretarioPostgrados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secretarioPostg == null)
            {
                return NotFound();
            }

            var count = _context.Entry(secretarioPostg).
                Collection(b => b.Matriculas).
                Query().
                Count();

            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar secretario {0} porque está asociada a {1} matrícula(s)", secretarioPostg.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(secretarioPostg);
        }

        // POST: SecretarioPostgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secretarioPostg = await _context.SecretarioPostgrados.FindAsync(id);
            _context.SecretarioPostgrados.Remove(secretarioPostg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecretarioPostgExists(int id)
        {
            return _context.SecretarioPostgrados.Any(e => e.Id == id);
        }
    }
}
