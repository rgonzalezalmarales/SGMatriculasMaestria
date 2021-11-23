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
    public class MunicipiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MunicipiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipios.ToListAsync());
        }

        public async Task<JsonResult> GetMinucipiosByProvinciaJson(int provinciaId)
        {
            var municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == provinciaId).
                Select(x => new { x.Id, x.Nombre }).ToListAsync();
            return Json(municipios);
        }

        [Authorize(Roles = "Tecnico,Especialista,Administrador")]
        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios.
                Include(x => x.Provincia).
                FirstOrDefaultAsync(m => m.Id == id);

            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]Municipio municipio)
        {
            //municipio.Provincia = await _context.Provincia.FindAsync(municipio.Provincia.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.Municipios.Where(x => x.Nombre == municipio.Nombre).FirstOrDefaultAsync();
                    if(m is not null)
                        throw new NegocioException("Ya existe un municipio con este nombre");
                    
                    _context.Add(municipio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }catch(NegocioException nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
                ViewBag.Provincias = await _context.Provincias.ToListAsync();
            }
            catch (Exception exp)
            {
                BadRequest(exp);
            }
            
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.Id))
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
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            var count = _context.Entry(municipio).
                Collection(b => b.Aspirantes).
                Query().
                Count();

            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar el municipio {0} porque esta asociado a {1} aspirante/s", municipio.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(e => e.Id == id);
        }
    }
}
