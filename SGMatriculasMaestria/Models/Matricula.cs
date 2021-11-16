using System;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        public int AspiranteId { get; set; }
        [Required]
        [Display(Name = "Aspirante")]
        public Aspirante Aspirante { get; set; }

        public int MaestriaId { get; set; }
        [Required]
        [Display(Name = "Maestria")]
        public Maestria Maestria { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Required]
        [Display(Name = "Fecha de culminación")]
        [DataType(DataType.Date)]
        public DateTime FechaCulminacion { get; set; }

        public int CentroTrabajoId { get; set; }
        [Required]
        [Display(Name = "Centro de trabajo")]
        public CentroTrabajo CentroTrabajo { get; set; }

        [Required]
        [Display(Name = "Motivo de solicitud")]
        [DataType(DataType.Text)]
        public string MotivoSolicitud { get; set; }

        public int SecretarioPostgId { get; set; }
        [Required]
        [Display(Name = "Secretario postgrado")]
        public SecretarioPostg SecretarioPostg { get; set; }

        [Required]
        [Display(Name = "Años de experiencia laboral")]
        public int AnnoExperienciaLaboral { get; set; }
        [Required]
        [Display(Name = "Fecha de matriculación")]
        [DataType(DataType.Date)]
        public DateTime FechaMatricula { get; set; }

        public int CategDocenteId { get; set; }
        [Required]
        [Display(Name ="CategDocente")]
        public CategDocente CategDocente { get; set; }

        public DateTime Modifiat { get; set; }

    }
}
