using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class Ces
    {
        public Ces()
        {
            Aspirantes = new HashSet<Aspirante>();              
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int? ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }

        public virtual ICollection<Aspirante> Aspirantes { get; set; }
    }
}
