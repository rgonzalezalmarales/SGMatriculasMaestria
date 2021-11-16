using System;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Aspirante
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(11)]
        [MinLength(11)]
        [Display(Name ="Carnet de Indentidad")]
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string DireccionParticular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaGraduacion { get; set; }
        public int Tomo { get; set; }
        public int Folio { get; set; }
        public int Numero { get; set; }

        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }

        public int EspecGraduadoId { get; set; }
        public EspecGraduado EspecGraduado { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public int CesId { get; set; }
        public Ces Ces { get; set; }

        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
