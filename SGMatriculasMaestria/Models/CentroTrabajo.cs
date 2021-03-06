using System;
using System.Collections.Generic;

namespace SGMatriculasMaestria.Models
{
    public class CentroTrabajo
    {
        public CentroTrabajo()
        {
            Matriculas = new HashSet<Matricula>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public int? ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
