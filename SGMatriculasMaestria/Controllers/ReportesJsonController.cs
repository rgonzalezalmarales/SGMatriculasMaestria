using Microsoft.AspNetCore.Mvc;
using SGMatriculasMaestria.Enums;
using SGMatriculasMaestria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Controllers
{
    public class ReportesJsonController : Controller
    {
        private readonly IReporteService _reporteService;
        public ReportesJsonController(IReporteService reporteService)
        {
            _reporteService = reporteService;                
        }

        [HttpGet]
        public async Task<IActionResult> GetAspirantesPorSexo(Sexo sexo)
        {
            return Json(await _reporteService.CountAspirantesPorSexoAsync(sexo));
        }
    }
}
