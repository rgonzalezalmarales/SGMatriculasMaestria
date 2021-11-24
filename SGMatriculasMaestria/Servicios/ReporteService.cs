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

        public async Task<long> TotalAspirantesAsync()
        {
            return await _context.Aspirantes.LongCountAsync();
        }

        public async Task<long> TotalMaestriasAsync()
        {
            return await _context.Aspirantes.LongCountAsync();
        }

        public async Task<long> TotalMatriculasAsync()
        {
            return await _context.Aspirantes.LongCountAsync();
        }

        public async Task<long> TotalAspirantesPendientesAsync()
        {
            return await _context.Aspirantes.Where(x=> x.Matriculas.Count() == 0).LongCountAsync();
        }

        public async Task<long> TotalMaestriasSinMatriculaAsync()
        {
            return await _context.Maestrias.Where(x => x.Matriculas.Count() == 0).LongCountAsync();
        }
    }
}
