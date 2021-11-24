using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.DTOs
{
    public class AspiranteReporteDto
    {
        public long TotalAspirantes { get; set; }
        public long TotalAspirantesPendientes { get; set; }
        public long TotalMatriculas { get; set; }
        public long TotalMaestriasSinMatricula { get; set; }
    }
}
