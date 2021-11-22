using System;
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
        [Required(ErrorMessage = "El campo 'titulos' es obligatorio")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo 'versión es' es obligatorio")]
        [Display(Name = "Versión")]
        public string Version { get; set; }


        public int FacultadId { get; set; }
        public Facultad Facultad { get; set; }


        public virtual ICollection<Matricula> Matriculas { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
