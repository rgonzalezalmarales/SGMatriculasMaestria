using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Maestria
    {
        public Maestria()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Versión")]
        public string Version { get; set; }

        public int FacultadId { get; set; }
        public Facultad Facultad { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
