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
    public class MaestriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaestriasController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: Maestrias
        public async Task<IActionResult> Index()
        {
            var maestrias = await _context.Maestrias.Include(x => x.Facultad).ToListAsync();
            return View(maestrias);
        }

        public  JsonResult GetMaestriasByFacultad(int? facultad)
        {           
            var maestrias =  _context.Maestrias.Where(x=>x.Facultad.Id== facultad).ToList();
            //var selectmaestrias = new SelectList(maestrias, "Id", "Titulo");
            return Json(maestrias);
        }

        
        // GET: Maestrias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maestria = await _context.Maestrias.
                Include(m => m.Facultad).
                FirstOrDefaultAsync(m => m.Id == id);
            if (maestria == null)
            {
                return NotFound();
            }

            return View(maestria);
        }

        // GET: Maestrias/Create
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Facultades = await _context.Facultades.ToListAsync();
            return View();
        }

        // POST: Maestrias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create(Maestria maestria)
        {
            try
            {
                //maestria.Facultad = _context.Facultades.Find(maestria.Facultad.Id);
                
                if (ModelState.IsValid)
                {
                    var m = await _context.Maestrias.
                    Where(x => x.Titulo == maestria.Titulo && x.Version == maestria.Version).
                    FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe una maestría con estos datos");

                    maestria.Creatat = DateTime.Now;
                    maestria.Modifiat = DateTime.Now;
                    _context.Add(maestria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Facultades = await _context.Facultades.ToListAsync();
                ViewBag.Facultades = await _context.Facultades.ToListAsync();
                ViewBag.ErrorMessage = ex.Message;
                
            }

            return View();

        }

        // GET: Maestrias/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maestria = await _context.Maestrias.
                FindAsync(id);
            if (maestria == null)
            {
                return NotFound();
            }

            ViewBag.Facultades = await _context.Facultades.ToListAsync();

            return View(maestria);
        }

        // POST: Maestrias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,Titulo,Version")]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int id, Maestria maestria)
        {
            if (id != maestria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    maestria.Modifiat = DateTime.Now;
                    _context.Update(maestria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaestriaExists(maestria.Id))
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
            return View(maestria);
        }

        // GET: Maestrias/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maestria = await _context.Maestrias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maestria == null)
            {
                return NotFound();
            }

            var count = _context.Entry(maestria).
                Collection(b => b.Matriculas).
                Query().
                Count();

            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar la maestría {0} porque está asociada a {1} matrícula(s)", maestria.Titulo, count);
                ViewBag.hidden = true;
            }

            return View(maestria);
        }

        // POST: Maestrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maestria = await _context.Maestrias.FindAsync(id);
            _context.Maestrias.Remove(maestria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaestriaExists(int id)
        {
            return _context.Maestrias.Any(e => e.Id == id);
        }
    }
}
