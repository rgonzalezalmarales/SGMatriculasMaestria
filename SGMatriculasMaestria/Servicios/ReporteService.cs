using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Enums;
using SGMatriculasMaestria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Servicios
{
    public class ReporteService : IReporteService
    {
        private readonly ApplicationDbContext _context;

        public ReporteService(ApplicationDbContext context)
        {
            _context = context;                
        }

        public async Task<int> CountAspirantesPorSexoAsync(Sexo sexo)
        {
            return await _context.Aspirantes.Where(x => x.SexoId == (int)sexo).CountAsync();
        }

        public async Task<int> CountAspirantesPorProvinciaAsync(int provinciaId)
        {
            return await _context.Aspirantes.Where(x => x.ProvinciaId == provinciaId).CountAsync();
        }

        public async Task<int> CountAspirantesPorMunicipioAsync(int municipioId)
        {
            return await _context.Aspirantes.Where(x => x.MunicipioId == municipioId).CountAsync();
        }
    }
}
