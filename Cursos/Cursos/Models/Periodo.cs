using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class Periodo
    {
        public Periodo()
        {
            Matricula = new HashSet<Matricula>();
        }

        [Key]
        public int IdPeriodo { get; set; }
        public int? Anio { get; set; }
        public bool? Estado { get; set; }

        //[InverseProperty("IdPeriodoNavigation")]        
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
