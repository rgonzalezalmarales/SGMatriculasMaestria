using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class Curso
    {
        public Curso()
        {
            InscripcionCurso = new HashSet<InscripcionCurso>();
        }

        [Key]
        public int IdCurso { get; set; }
        [StringLength(10)]
        public string Codigo { get; set; }
        [StringLength(100)]
        public string Descripsion { get; set; }
        public bool? Estado { get; set; }

        //[InverseProperty("IdCursoNavigation")]
        public virtual ICollection<InscripcionCurso> InscripcionCurso { get; set; }
    }
}
