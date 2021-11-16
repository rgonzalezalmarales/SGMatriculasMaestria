using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Facultad
    {
        public Facultad()
        {
            Maestrias = new HashSet<Maestria>();                
        }
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Nombre de la Facultad")]
        public string Nombre { get; set; }
        public virtual ICollection<Maestria> Maestrias { get; set; }
        
    }
}
