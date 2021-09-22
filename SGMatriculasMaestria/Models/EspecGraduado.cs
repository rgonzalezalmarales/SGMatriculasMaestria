using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class EspecGraduado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Aspirante> Aspirantes { get; set; }
    }
}
