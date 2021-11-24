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
    //[Authorize(Roles = "Especialista")]
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
        //[Authorize(Roles = "Tecnico,Especialista,Administrador")]
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

        //[Authorize(Roles = "Tecnico,Especialista,Administrador")]
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
        [Authorize(Roles ="Especialista")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Especialidades = await _context.EspecGraduados.ToListAsync();
            ViewBag.Ces = await _context.Ces.ToListAsync();
            ViewBag.Paises = await _context.Paises.ToListAsync();
            ViewBag.Provincias = new List<Provincia>();
            ViewBag.Municipios = new List<Municipio>();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> FilterAjaxAspirante(string search)
        {
            //|| x.CI.ToString().ToUpper().Contains(query.ToUpper())
            /*var aspirantes = await _context.Aspirantes.
                Where(x => string.Concat(x.CI,x.Nombre, x.PrimerApellido, x.SegundoApellido).ToUpper().Contains(query.ToUpper()) ).
                ToListAsync();*/

            var aspirantes = await _context.Aspirantes.
               Where(x => x.CI.Contains(search) || 
                    x.Nombre.Contains(search) || 
                    x.PrimerApellido.Contains(search) || 
                    x.SegundoApellido.Contains(search)).
               ToListAsync();


            return Json(aspirantes);
        }

        // POST: Aspirantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Especialista")]
        [ValidateAntiForgeryToken]
        //[Bind("CI,Nombre,PrimerApellido,DireccionParticular,Telefono,Email,FechaGraduacion,Tomo,Folio,Numero,Sexo")]
        public async Task<IActionResult> Create( Aspirante aspirante)
        {
            var aspiranteDb = await _context.Aspirantes.Where(a => a.CI == aspirante.CI).FirstOrDefaultAsync();
            if(aspiranteDb == null)
            {
                if (ModelState.IsValid)
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
        [Authorize(Roles = "Especialista")]
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

            
            if (aspirante == null)
            {
                return NotFound();
            }

            ViewBag.Especialidades = await _context.EspecGraduados.ToListAsync();
            ViewBag.Ces = await _context.Ces.ToListAsync();
            ViewBag.Paises = await _context.Paises.ToListAsync();
            ViewBag.Provincias = await _context.Provincias.Where(x => x.PaisId == aspirante.PaisId).ToListAsync();
            ViewBag.Municipios = await _context.Municipios.Where(x => x.ProvinciaId == aspirante.ProvinciaId).ToListAsync();

            return View(aspirante);
        }

        // POST: Aspirantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Especialista")]
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
        [Authorize(Roles = "Especialista")]
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
            
            var count = _context.Entry(aspirante).
              Collection(b => b.Matriculas).
              Query().
              Count();


            if (count > 0)
            {
                ViewBag.ErrorMessage = string.Format("No se puede eliminar el aspirante {0} porque está asociado a {1} matrícula(s)", aspirante.Nombre, count);
                ViewBag.hidden = true;
            }

            return View(aspirante);
        }

        // POST: Aspirantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Especialista")]
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
