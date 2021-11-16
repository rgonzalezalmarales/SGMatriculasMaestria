using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class Pais
    {
        public Pais()
        {
            Aspirantes = new HashSet<Aspirante>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }
    }
}
