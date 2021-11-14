using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class Maestria
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Versión")]
        public string Version { get; set; }
        public Facultad Facultad { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}
