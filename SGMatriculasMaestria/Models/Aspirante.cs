using SGMatriculasMaestria.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Aspirante
    {
        [Key]
        [Display(Name = "Carnet de Indentidad")]        
        public string CI { get; set; }

        [Required(ErrorMessage = "El campo 'nombre' es obligatorio")]
        public string Nombre { get; set; }
        
        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El campo 'apellido' es obligatorio")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "El campo 'apellido' es obligatorio")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Dirección Particular")]
        [Required(ErrorMessage = "El campo 'dirección' es obligatorio")]
        public string DireccionParticular { get; set; }
        
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
       
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Display(Name = "Fecha de graduación")]
        [Required(ErrorMessage = "El campo 'fecha de graduación' es obligatorio")]
        public DateTime FechaGraduacion { get; set; }

        [Required(ErrorMessage = "El campo 'tomo' es obligatorio")]
        public int Tomo { get; set; }

        [Required(ErrorMessage = "El campo 'folo' es obligatorio")]
        public int Folio { get; set; }

        [Required(ErrorMessage = "El campo 'número' es obligatorio")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El campo 'sexo' es obligatorio")]
        public int SexoId { get; set; }        
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "El campo 'especialidad' es obligatorio")]
        public int EspecGraduadoId { get; set; }
        [Display(Name = "Especialidad")]
        public EspecGraduado EspecGraduado { get; set; }

        public int? PaisId { get; set; }
        public Pais Pais { get; set; }

        [Required(ErrorMessage = "El campo 'universidad' es obligatorio")]
        public int CesId { get; set; }
        [Display(Name = "Universidad")]
        public Ces Ces { get; set; }

        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        public int? ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
