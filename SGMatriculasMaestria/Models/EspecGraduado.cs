using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class EspecGraduado
    {
        public EspecGraduado()
        {
            Aspirantes = new HashSet<Aspirante>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }
    }
}
