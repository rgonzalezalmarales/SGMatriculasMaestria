using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class Matricula
    {
        public Matricula()
        {
            InscripcionCurso = new HashSet<InscripcionCurso>();
        }

        [Key]
        public int IdEstudiante { get; set; }
        
        [Key]
        public int IdPeriodo { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        [ForeignKey(nameof(IdEstudiante))]
        //[InverseProperty(nameof(Estudiante.Matricula))]
        public virtual Estudiante Estudiante { get; set; }
        
        [ForeignKey(nameof(IdPeriodo))]
        //[InverseProperty(nameof(Periodo.Matricula))]
        public virtual Periodo Periodo { get; set; }
        
        
        //[InverseProperty("Id")]
        //[ForeignKey(nameof(IdEstudiante) + "," + nameof(IdPeriodo))]
        public virtual ICollection<InscripcionCurso> InscripcionCurso { get; set; }
    }
}
