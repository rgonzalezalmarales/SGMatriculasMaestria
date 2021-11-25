using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.Enums;
using SGMatriculasMaestria.Interfaces;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Servicios
{
    public class Par
    {
        public string Key { get; set; }
        public int Value { get; set; }

    }

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

        public async Task<int> TotalAspirantesAsync()
        {
            var result = await _context.Aspirantes.CountAsync();
            return result;
        }

        public async Task<int> TotalMaestriasAsync()
        {
            var result = await _context.Maestrias.CountAsync();
            return result;
        }

        public async Task<int> TotalMatriculasActivasAsync()
        {
            var result = await _context.Matricula.Where(x => x.FechaInicio < DateTime.Now && x.FechaCulminacion > DateTime.Now).CountAsync();
            return result;
        }

        public async Task<int> TotalAspirantesPendientesAsync()
        {
            var result = await _context.Aspirantes.Where(x => x.Matriculas.Count() == 0).CountAsync();
            //if (result is null)
                //return 0;

            return result;
        }

        public async Task<List<Par>> ProvinciasAspirantes()
        {
            var a = await  _context.Provincias.Select(x => new Par (){ Value = x.Aspirantes.Count, Key = x.Nombre }).ToListAsync();

            return a;
        }

        public async Task<List<Par>> MunicipiosAspirantes(int provinciaId)
        {
            return await _context.Municipios.
                Where(x => x.ProvinciaId == provinciaId).
                Select(x => new Par() { Value = x.Aspirantes.Count, Key = x.Nombre }).ToListAsync();
        }
    }
}
