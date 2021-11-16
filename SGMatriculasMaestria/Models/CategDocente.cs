using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class CategDocente
    {
        public CategDocente()
        {
            Matriculas = new HashSet<Matricula>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
