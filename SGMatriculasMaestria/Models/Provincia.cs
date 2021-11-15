using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
        }
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
