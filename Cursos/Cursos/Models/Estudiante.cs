using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cursos.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matricula = new HashSet<Matricula>();
        }

        [Key]
        public int IdEstudiante { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "El código es obligatrio")]
        [MinLength(10, ErrorMessage = "El código debe ser mínimo de 10 caracteres")]
        [MaxLength(10, ErrorMessage = "El código debe ser máximo de 10 caracteres")]
        
        public string Codigo { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [MinLength(3, ErrorMessage ="El nombre de ser mínimo de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre de ser máximo de 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre de ser mínimo de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre de ser máximo de 50 caracteres")]
        public string Apellido { get; set; }

        //[Required]
        //[StringLength(101)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NombreApellido { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha no es válida")]
        public DateTime? FechaNacimiento { get; set; }

        //[InverseProperty("IdEstudianteNavigation")]
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
