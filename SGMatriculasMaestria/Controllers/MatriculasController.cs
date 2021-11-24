using System;
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
    public class MatriculasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MatriculasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matricula.Include(x=>x.Aspirante).ToListAsync());
        }

       
        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula.
                Include(x => x.Aspirante).
                Include(x => x.CategDocente).
                Include(x => x.CentroTrabajo).
                Include(x => x.Maestria).
                Include(x => x.SecretarioPostg)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        [Authorize(Roles = "Especialista")]
        public IActionResult Create()
        {
            ViewBag.Facultades = _context.Facultades.ToList();
            ViewBag.CategoriasDocentes = _context.CategDocentes.ToList();
            ViewBag.SecretarioPost = _context.SecretarioPostgrados.ToList();
            ViewBag.CentrosTrabajo = _context.CentroTrabajos.ToList();
            ViewBag.Maestrias = new List<Maestria>();



            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Create(MatriculaDto matriculaDto)
        {
            /*//

            var aspirante = await _context.Aspirantes.FindAsync(matricula.AspiranteCI);
            if (aspirante is not null)*/
            Matricula matricula = _mapper.Map<Matricula>(matriculaDto);
            
            if (ModelState.IsValid)
            {
                matricula.Creatat = DateTime.Now;
                matricula.Modifiat = DateTime.Now;
                matricula.FechaMatricula = DateTime.Now;
                //matricula.Aspirante = aspirante;

                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            

            ViewBag.Facultades = await _context.Facultades.ToListAsync();
            ViewBag.CategoriasDocentes = await _context.CategDocentes.ToListAsync();
            ViewBag.SecretarioPost = await _context.SecretarioPostgrados.ToListAsync();
            ViewBag.CentrosTrabajo = await _context.CentroTrabajos.ToListAsync();
            ViewBag.Maestrias = await _context.Maestrias.Where(x=> x.Id == matriculaDto.MaestriaId).ToListAsync();
            //matricula
            ViewBag.ErrorMessage = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));


            return View(matriculaDto);
        }

        // GET: Matriculas/Edit/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            
            var matricula = await _context.Matricula.
                Include(m => m.Maestria).
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            var matriculaDto = _mapper.Map<MatriculaDto>(matricula);

            if (matricula == null)
            {
                return NotFound();
            }

            ViewBag.Facultades = await _context.Facultades.ToListAsync();
            ViewBag.CategoriasDocentes = await _context.CategDocentes.ToListAsync();
            ViewBag.SecretarioPost = await _context.SecretarioPostgrados.ToListAsync();
            ViewBag.CentrosTrabajo = await _context.CentroTrabajos.ToListAsync();
            ViewBag.Maestrias = await _context.Maestrias.Where(m => m.FacultadId == matricula.Maestria.FacultadId).ToListAsync();
            matriculaDto.FacultadId = matricula.Maestria.FacultadId;
            return View(matriculaDto);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        //[Bind("Id,FechaInicio,FechaCulminacion,MotivoSolicitud,AnnoExperienciaLaboral,FechaMatricula")]
        public async Task<IActionResult> Edit(int id, MatriculaDto matriculaDto)
        {

            var matricula = _mapper.Map<Matricula>(matriculaDto);
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    matricula.Maestria = null;
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
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

            ViewBag.Facultades = await _context.Facultades.ToListAsync();
            ViewBag.CategoriasDocentes = await _context.CategDocentes.ToListAsync();
            ViewBag.SecretarioPost = await _context.SecretarioPostgrados.ToListAsync();
            ViewBag.CentrosTrabajo = await _context.CentroTrabajos.ToListAsync();
            ViewBag.Maestrias = await _context.Maestrias.Where(m => m.FacultadId == matriculaDto.FacultadId).ToListAsync();


            return View(matriculaDto);
        }

        // GET: Matriculas/Delete/5
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matricula.FindAsync(id);
            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matricula.Any(e => e.Id == id);
        }
    }
}
