using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class Provincia
    {
        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
