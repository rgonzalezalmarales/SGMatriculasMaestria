using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
            CentroTrabajos = new HashSet<CentroTrabajo>();
            Ces = new HashSet<Ces>();
            Aspirantes = new HashSet<Aspirante>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
        public virtual ICollection<CentroTrabajo> CentroTrabajos { get; set; }
        public virtual ICollection<Ces> Ces { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
