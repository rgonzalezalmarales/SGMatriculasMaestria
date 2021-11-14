using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class Ces
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Municipio Municipio { get; set; }
        public List<Aspirante> Aspirantes { get; set; }
    }
}
