using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
