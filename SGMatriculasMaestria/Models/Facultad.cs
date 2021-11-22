using System;
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
        [Required(ErrorMessage = "El campo 'nombre de la facultad' es obligatorio.")]
        [DataType(DataType.Text)]
        [Display(Name ="Nombre de la Facultad")]
        public string Nombre { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
        public virtual ICollection<Maestria> Maestrias { get; set; }
        
    }
}
