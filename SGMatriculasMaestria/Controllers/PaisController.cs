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
    public class PaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: Pais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paises.ToListAsync());
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Pais pais)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.Paises.Where(x => x.Nombre == pais.Nombre).FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe una pais con este nombre");
                    
                    pais.Creatat = DateTime.Now;
                    pais.Modifiat = DateTime.Now;
                    _context.Add(pais);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (NegocioException nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
                ViewBag.Provincias = await _context.Provincias.ToListAsync();
            }
            catch (Exception exp)
            {
                BadRequest(exp);
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Pais pais)
        {
            if (id != pais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pais.Modifiat = DateTime.Now;
                    _context.Update(pais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisExists(pais.Id))
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
            return View(pais);
        }

        // GET: Pais/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            //var p = _context.Paises.Include(p => new { a = p.Aspirantes.Count });
            //ViewBag.ErrorMessage = p;
            var aspirantesCount = _context.Entry(pais).
                Collection(b => b.Aspirantes).
                Query().
                Count();

            
            if(aspirantesCount > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar el pais {0} porque esta asociado a {1} aspirante(s)", pais.Nombre, aspirantesCount);
                ViewBag.hidden = true;
            }

            var countCt = 0;
            var pais_prov = await _context.Paises.Include(p => p.Provincias).
                Where(pi => pi.Id == pais.Id).
                FirstOrDefaultAsync();
            if(pais_prov is not null){
                bool flag = false;
                foreach (var p in pais_prov.Provincias)
                {
                    countCt = _context.Entry(p).Collection(b => b.Aspirantes).Query().Count();
                    if(countCt > 0)
                    {
                        flag = true;
                        break;
                    }
                    countCt = _context.Entry(p).Collection(b => b.Ces).Query().Count();
                    if (countCt > 0)
                    {
                        flag = true;
                        break;
                    }
                    countCt = _context.Entry(p).Collection(b => b.CentroTrabajos).Query().Count();
                    if (countCt > 0)
                    {
                        flag = true;
                        break;
                    }

                }
                if (flag)
                {
                    ViewBag.ErrorMessage = string.Format("No se puede eliminar el pais {0} porque está asociado a {1} registro(s).", pais.Nombre, countCt);
                    ViewBag.hidden = true;
                }

            }
            

            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }
    }
}
