using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Provincia Provincia { get; set; }
        public List<CentroTrabajo> CentroTrabajos { get; set; }
        public List <Ces> Ces { get; set; }
        public List<Aspirante> Aspirantes { get; set; }

    

    }
}
