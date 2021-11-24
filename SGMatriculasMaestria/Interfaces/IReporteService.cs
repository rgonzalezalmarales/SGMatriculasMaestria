using SGMatriculasMaestria.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Interfaces
{
    public interface IReporteService
    {
        Task<int> CountAspirantesPorSexoAsync(Sexo sexo);
        Task<int> CountAspirantesPorProvinciaAsync(int provinciaId);
        Task<int> CountAspirantesPorMunicipioAsync(int municipioId);
        Task<long> TotalMaestriasSinMatriculaAsync();
        Task<long> TotalAspirantesPendientesAsync();
        Task<long> TotalMatriculasAsync();
        Task<long> TotalAspirantesAsync();
    }
}
