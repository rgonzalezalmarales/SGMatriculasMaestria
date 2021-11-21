using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using SGMatriculasMaestria.Enums;

namespace SGMatriculasMaestria.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            AspirantesReport reporte = new AspirantesReport();

            var matriculas =await _context.Matricula.ToListAsync();
            var aspirantes =await _context.Aspirantes.ToListAsync();
            if (aspirantes.Count == 0)
            {
                reporte.AspirantesConMatriculas = 0;
                reporte.AspirantesSinMatriculas = 0;
                reporte.AspirantesMensuales = 0;
                reporte.AspirantesAnuales = 0;
                reporte.AspirantesMasculinos = 0;
                reporte.PorcientoDeAspirantesPorMatriculas = 0;
                reporte.AspirantesFemeninos = 0;
                ViewBag.AspiranteReporte = reporte;
                return View();
            }
            else if (matriculas.Count == 0)
            {
                reporte.AspirantesConMatriculas = 0;
                reporte.AspirantesSinMatriculas = aspirantes.Count;
                reporte.PorcientoDeAspirantesPorMatriculas = 0;
                reporte.AspirantesMensuales = Convert.ToInt32(aspirantes.Count / ((primeraspirante(aspirantes) - DateTime.UtcNow).TotalDays) / 30);
                reporte.AspirantesAnuales = Convert.ToInt32(aspirantes.Count / ((primeraspirante(aspirantes) - DateTime.UtcNow).TotalDays) / 365);
                reporte.AspirantesMasculinos = aspirantes.Count(x => x.Sexo == Sexo.Masculino);
                reporte.AspirantesFemeninos = aspirantes.Count() - reporte.AspirantesMasculinos;
                ViewBag.AspiranteReporte = reporte;
                return View();
            }
            reporte.AspirantesConMatriculas = cantidadmatriculados(aspirantes, matriculas);
            reporte.AspirantesSinMatriculas = matriculas.Count() - reporte.AspirantesConMatriculas;
            reporte.AspirantesMensuales = Convert.ToInt32(aspirantes.Count / ((primeraspirante(aspirantes) - DateTime.UtcNow).TotalDays) / 30);
            reporte.AspirantesAnuales = Convert.ToInt32(aspirantes.Count / ((primeraspirante(aspirantes) - DateTime.UtcNow).TotalDays) / 365);
            reporte.AspirantesMasculinos = aspirantes.Count(x => x.Sexo == Sexo.Masculino);
            reporte.PorcientoDeAspirantesPorMatriculas = Convert.ToInt32((reporte.AspirantesConMatriculas / aspirantes.Count) * 100);
            reporte.AspirantesFemeninos = aspirantes.Count() - reporte.AspirantesMasculinos;
            ViewBag.AspiranteReporte = reporte;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int cantidadmatriculados(List<Aspirante> aspirantes,List<Matricula> matriculas)
        {
            int cant = 0;
            foreach (var item in aspirantes)
            {
                if (matriculas.Exists(x=>x.Aspirante.CI == item.CI))
                {
                    cant++;
                }
            }
            return cant;
        }
        public DateTime primeraspirante(List<Aspirante> aspirantes)
        {
            aspirantes.OrderBy(x=>x.Creatat);
            return aspirantes[0].Creatat;
        }
    }
}
