using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public partial class Municipio
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        [ForeignKey(nameof(ProvinciaId))]
        public ICollection<CentroTrabajo> CentroTrabajos { get; set; }
        public ICollection<Ces> Ces { get; set; }
        public ICollection<Aspirante> Aspirantes { get; set; }

    

    }
}
