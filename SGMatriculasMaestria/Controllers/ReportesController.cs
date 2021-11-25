using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private readonly IReporteService _reporteService;
        private readonly ApplicationDbContext _context;

        public ReportesController(IReporteService reporteService, ApplicationDbContext context)
        {
            _reporteService = reporteService;
            _context = context;
        }
        // GET: ReportesController
        public async Task<ActionResult> Index()
        {
            /*
            ViewBag.Mujeres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Femenino);
            ViewBag.Hombres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Masculino);
            */

            ViewBag.Provincias = await _context.Provincias.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GraficaPorSexo()
        {
            var tempo = new
            {
                Hombres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Masculino),
                Mujeres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Femenino)
            };

            return Json(tempo);
        }

        [HttpPost]
        public async Task<JsonResult> GraficaPorProv()
        {
            var a = await _reporteService.ProvinciasAspirantes();
            return Json(a);
        }

        [HttpPost]
        public async Task<JsonResult> GraficaPorMunic(int provinciaId)
        {
            try
            {
                var a = await _reporteService.MunicipiosAspirantes(provinciaId);
                return Json(a);
            }
            catch (Exception)
            {
                return Json("[]");
            }
            
        }

        // GET: ReportesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
