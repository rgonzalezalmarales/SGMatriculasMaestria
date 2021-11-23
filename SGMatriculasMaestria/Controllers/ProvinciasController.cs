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
    [Authorize(Roles = "Especialista")]
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provincias.ToListAsync());
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        public async Task<JsonResult> GetProvinciasByPaisJson(int paisId)
        {
            var provincias = await _context.Provincias.
                Where(x => x.PaisId == paisId).
                Select(x => new { x.Id, x.Nombre }).ToListAsync();
            return Json(provincias);
        }

        // GET: Provincias/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Paises = await _context.Paises.ToListAsync();
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,PaisId")] Provincia provincia)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.Provincias.Where(x => x.Nombre == provincia.Nombre).FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe una provincia con este nombre");

                    _context.Add(provincia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (NegocioException nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
                ViewBag.Paises = await _context.Paises.ToListAsync();
            }
            catch (Exception exp)
            {
                BadRequest(exp);
            }
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciaExists(provincia.Id))
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
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            var count = _context.Entry(provincia).
               Collection(b => b.Aspirantes).
               Query().
               Count();

            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar el provincia {0} porque esta asociado a {1} aspirante/s", provincia.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            

            /*try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {
                    // _context.Provincia.FindAsync(id);
                   //var provincia = await _context.Provincia.Include(x => x.Municipios).FirstOrDefaultAsync(x => x.Id == id);
                    try
                    {
                        //var municipios = await _context.Municipios.Select(x => x.Provincia.Id == id).ToListAsync();
                        //_context.RemoveRange(municipios);
                        _context.Provincia.Remove(provincia);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine("Mensaje de error de prueba", e);
                    }                    
                }
                
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("Mensaje de error de prueba",e);
            }*/
            try
            {
                var provincia = await _context.Provincias.FindAsync(id);
                _context.Provincias.Remove(provincia);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("Mensaje de error de prueba", e);
            }
            return RedirectToAction(nameof(Index));
         }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincias.Any(e => e.Id == id);
        }
    }
}
