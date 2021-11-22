using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public partial class Municipio
    {
        //[ForeignKey(nameof(ProvinciaId))]
        public Municipio()
        {
            CentroTrabajos = new HashSet<CentroTrabajo>();
            Ces = new HashSet<Ces>();
            Aspirantes = new HashSet<Aspirante>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        public virtual ICollection<CentroTrabajo> CentroTrabajos { get; set; }
        public virtual ICollection<Ces> Ces { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
