using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class InscripcionCurso
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Key]
        public int IdPeriodo { get; set; }

        [Key]
        public int IdCurso { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        //nameof(IdEstudiante), nameof(IdPeriodo)


        //[InverseProperty(nameof(Cursos.Models.Matricula.InscripcionCurso))]
        [ForeignKey(nameof(IdEstudiante) + "," + nameof(IdPeriodo))]
        public virtual Matricula Matricula { get; set; }

        //[InverseProperty(nameof(Cursos.Models.Curso.InscripcionCurso))]
        [ForeignKey(nameof(IdCurso))]
        public virtual Curso Curso { get; set; }
    }
}
