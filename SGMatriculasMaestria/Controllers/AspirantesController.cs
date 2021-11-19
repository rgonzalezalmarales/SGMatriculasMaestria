﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.DTOs;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Controllers
{
    [Authorize]
    public class AspirantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AspirantesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Aspirantes
        public async Task<IActionResult> Index()
        {
            var aspirantes = await _context.Aspirantes.
                OrderBy(x => x.Nombre).
                Include(x => x.EspecGraduado).
                Include(c => c.Ces).
                Include(m => m.Municipio).
                ToListAsync();

            //var aspiranteDtos = _mapper.Map<List<AspiranteDto>>(aspirantes);
            return View(aspirantes);
        }

        // GET: Aspirantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspirante = await _context.Aspirantes.
                Include(p => p.Ces).
                Include(x => x.EspecGraduado).
                Include(x => x.Pais).
                Include(p => p.Provincia).
                Include(m => m.Municipio).
                FirstOrDefaultAsync(m => m.CI == id);

            if (aspirante == null)
            {
                return NotFound();
            }

            return View(aspirante);
        }

        // GET: Aspirantes/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Especialidades = await _context.EspecGraduados.ToListAsync();
            ViewBag.Ces = await _context.Ces.ToListAsync();
            ViewBag.Paises = await _context.Paises.ToListAsync();
            ViewBag.Provincias = new List<Provincia>();
            ViewBag.Municipios = new List<Municipio>();
            return View();
        }

        // POST: Aspirantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("CI,Nombre,PrimerApellido,DireccionParticular,Telefono,Email,FechaGraduacion,Tomo,Folio,Numero,Sexo")]
        public async Task<IActionResult> Create( Aspirante aspirante)
        {
            var aspiranteDb = await _context.Aspirantes.Where(a => a.CI == aspirante.CI).FirstOrDefaultAsync();
            if(aspiranteDb == null)
            {
                if (aspiranteDb != null && ModelState.IsValid)
                {
                    aspirante.Creatat = DateTime.Now;
                    aspirante.Modifiat = DateTime.Now;
                    _context.Add(aspirante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.ErrorMessage =  "Ya existe un aspirante con este carnet de identidad";
            }

            ViewBag.Especialidades = await _context.EspecGraduados.ToListAsync();
            ViewBag.Ces = await _context.Ces.ToListAsync();
            ViewBag.Paises = await _context.Paises.ToListAsync();
            ViewBag.Provincias = await _context.Provincias.Where(x => x.PaisId == aspirante.PaisId).ToListAsync();
            ViewBag.Municipios = await _context.Municipios.Where(x => x.ProvinciaId == aspirante.ProvinciaId).ToListAsync();



            return View(aspirante);
        }

        // GET: Aspirantes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var aspirante = await _context.Aspirantes.
                Where(a => a.CI == id).
                Include(x => x.Ces).
                Include(x => x.EspecGraduado).
                Include(x => x.Pais).
                Include(x => x.Provincia).
                Include(x => x.Municipio).
                FirstAsync();*/
            var aspirante = await _context.Aspirantes.FirstOrDefaultAsync(m => m.CI == id);

            ViewBag.Especialidades = await _context.EspecGraduados.ToListAsync();
            ViewBag.Ces = await _context.Ces.ToListAsync();
            ViewBag.Paises = await _context.Paises.ToListAsync();
            ViewBag.Provincias = await _context.Provincias.Where(x => x.PaisId == aspirante.PaisId).ToListAsync();
            ViewBag.Municipios = await _context.Municipios.Where(x => x.ProvinciaId == aspirante.ProvinciaId).ToListAsync();
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
        public async Task<IActionResult> Edit(string id,Aspirante aspirante)
        {
            if (id != aspirante.CI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    aspirante.Modifiat = DateTime.Now;
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
