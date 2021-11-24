﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;                
        }
        // GET: ReportesController
        public async Task<ActionResult> Index()
        {
            ViewBag.Mujeres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Femenino);
            ViewBag.Hombres = await _reporteService.CountAspirantesPorSexoAsync(Enums.Sexo.Masculino);

            return View();
        }

        [HttpPost]
        /*public async Task<JsonResult> GraficaPorSexo() { 

        }*/

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
