using SGMatriculasMaestria.Enums;
using SGMatriculasMaestria.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Interfaces
{
    public interface IReporteService
    {
        Task<int> CountAspirantesPorSexoAsync(Sexo sexo);
        Task<List<Par>> MunicipiosAspirantes(int provinciaId);
        Task<List<Par>> ProvinciasAspirantes();
        Task<int> TotalAspirantesAsync();
        Task<int> TotalAspirantesPendientesAsync();
        Task<int> TotalMaestriasAsync();
        Task<int> TotalMatriculasActivasAsync();
    }
}
