using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class CentroTrabajo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public Municipio Municipio { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}
