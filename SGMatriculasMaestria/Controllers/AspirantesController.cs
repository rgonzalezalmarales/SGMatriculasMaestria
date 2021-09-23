﻿using System;
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
    public class AspirantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AspirantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aspirantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aspirantes.ToListAsync());
        }

        // GET: Aspirantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.Aspirantes
                .FirstOrDefaultAsync(m => m.CI == id);
            if (aspirante == null)
            {
                return NotFound();
            }

            return View(aspirante);
        }

        // GET: Aspirantes/Create
        public IActionResult Create()
        {
            ViewBag.Especialidades = _context.EspecGraduados.ToList();
            ViewBag.Ces = _context.Ces.ToList();
            ViewBag.Pais = _context.Paises.ToList();
            ViewBag.Municipios = _context.Municipios.ToList();
            ViewBag.Generos = new List<Sexo> {Sexo.Femenino,Sexo.Masculino};
            return View();
        }

        // POST: Aspirantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CI,Nombre,PrimerApellido,DireccionParticular,Telefono,Email,FechaGraduacion,Tomo,Folio,Numero,Sexo")] Aspirante aspirante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspirante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspirante);
        }

        // GET: Aspirantes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.Aspirantes.FindAsync(id);
            if (aspirante == null)
            {
                return NotFound();
            }
            return View(aspirante);
        }

        // POST: Aspirantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CI,Nombre,PrimerApellido,DireccionParticular,Telefono,Email,FechaGraduacion,Tomo,Folio,Numero,Sexo")] Aspirante aspirante)
        {
            if (id != aspirante.CI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspirante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspiranteExists(aspirante.CI))
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
            return View(aspirante);
        }

        // GET: Aspirantes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.Aspirantes
                .FirstOrDefaultAsync(m => m.CI == id);
            if (aspirante == null)
            {
                return NotFound();
            }

            return View(aspirante);
        }

        // POST: Aspirantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aspirante = await _context.Aspirantes.FindAsync(id);
            _context.Aspirantes.Remove(aspirante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspiranteExists(string id)
        {
            return _context.Aspirantes.Any(e => e.CI == id);
        }
    }
}
