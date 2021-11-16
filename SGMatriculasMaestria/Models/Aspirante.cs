using System;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Aspirante
    {

        [Display(Name = "Carnet de Indentidad")]
        [Required(ErrorMessage = "El carnet de identidad es obligatorio")]
        [DataType(DataType.Text)]
        [MinLength(11, ErrorMessage = "El carnet de identidad debe ser de 11 caracteres")]
        [MaxLength(11, ErrorMessage = "El carnet de identidad debe ser de 11 caracteres")]
        public string CI { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        
        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Dirección Particular")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string DireccionParticular { get; set; }
        
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
       
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Display(Name = "Fecha de graduación")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [DataType(DataType.DateTime, ErrorMessage = "Solo se permiten fechas válidas")]
        public DateTime FechaGraduacion { get; set; }

        [Required(ErrorMessage = "El tomo es obligatorio")]
        public int Tomo { get; set; }

        [Required(ErrorMessage = "El folio es obligatorio")]
        public int Folio { get; set; }

        [Required(ErrorMessage = "El número es obligatorio")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        public int SexoId { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        public Sexo Sexo { get; set; }

        public int EspecGraduadoId { get; set; }
        [Display(Name = "Especialidad")]
        public EspecGraduado EspecGraduado { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public int CesId { get; set; }
        [Display(Name = "Úniversidad")]
        public Ces Ces { get; set; }

        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
