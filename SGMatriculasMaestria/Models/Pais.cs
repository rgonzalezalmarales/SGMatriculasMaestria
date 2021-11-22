using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class Pais
    {
        public Pais()
        {
            Aspirantes = new HashSet<Aspirante>();
            Provincias = new HashSet<Provincia>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }
        public virtual ICollection<Provincia> Provincias { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
