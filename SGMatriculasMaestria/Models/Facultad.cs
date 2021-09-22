using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Models
{
    public class Facultad
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Nombre de la Facultad")]
        public string Nombre { get; set; }
        public List<Maestria> Maestrias { get; set; }
        
    }
}
