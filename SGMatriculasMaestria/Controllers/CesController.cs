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
    public class CesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: Ces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ces.ToListAsync());
        }

        
        // GET: Ces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ces = await _context.Ces.
                Include(p => p.Provincia).
                Include(m => m.Municipio).
                FirstOrDefaultAsync(m => m.Id == id);
            if (ces == null)
            {
                return NotFound();
            }

            return View(ces);
        }

        // GET: Ces/Create
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = new List<Municipio>();
            return View();
        }

        // POST: Ces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,Nombre,Descripcion")]
        public async Task<IActionResult> Create(Ces ces)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var m = await _context.Ces.Where(x => x.Nombre == ces.Nombre).FirstOrDefaultAsync();
                    if (m is not null)
                        throw new NegocioException("Ya existe una universidad con este nombre");

                    ces.Creatat = DateTime.Now;
                    ces.Modifiat = DateTime.Now;
                    _context.Add(ces);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception nexp)
            {
                ViewBag.ErrorMessage = nexp.Message;
            }/*
            catch (Exception exp)
            {
                BadRequest(exp);
            }*/

            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == ces.ProvinciaId).
                ToListAsync();

            return View(ces);
        }

        // GET: Ces/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ces = await _context.Ces.FindAsync(id);
            if (ces == null)
            {
                return NotFound();
            }

            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Municipios = await _context.Municipios.
                Where(x => x.ProvinciaId == ces.ProvinciaId).
                ToListAsync();

            return View(ces);
        }

        // POST: Ces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        // [Bind("Id,Nombre,Descripcion")] 
        public async Task<IActionResult> Edit(int id,Ces ces)
        {
            if (id != ces.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ces.Modifiat = DateTime.Now;
                    _context.Update(ces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CesExists(ces.Id))
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
                Where(x => x.ProvinciaId == ces.ProvinciaId).
                ToListAsync();

            return View(ces);
        }

        // GET: Ces/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ces = await _context.Ces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ces == null)
            {
                return NotFound();
            }

            var count = _context.Entry(ces).
                Collection(b => b.Aspirantes).
                Query().
                Count();

            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar la universidad {0} porque está asociada a {1} aspirante/s", ces.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(ces);
        }

        // POST: Ces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ces = await _context.Ces.FindAsync(id);
            _context.Ces.Remove(ces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CesExists(int id)
        {
            return _context.Ces.Any(e => e.Id == id);
        }
    }
}
