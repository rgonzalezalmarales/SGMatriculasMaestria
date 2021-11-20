using System;
using System.ComponentModel.DataAnnotations;

namespace SGMatriculasMaestria.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "El campo 'aspirante' es obligatorio")]
        public int? AspiranteId { get; set; }        
        [Display(Name = "Aspirante")]
        public Aspirante Aspirante { get; set; }

        //[Required(ErrorMessage = "El campo 'maestria' es obligatorio")]
        public int MaestriaId { get; set; }
        [Display(Name = "Maestría")]
        public Maestria Maestria { get; set; }

        [Required(ErrorMessage = "El campo 'fecha de inicio' es obligatorio")]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo 'fecha de culminación' es obligatorio")]
        [Display(Name = "Fecha de culminación")]
        [DataType(DataType.Date)]
        public DateTime FechaCulminacion { get; set; }

        //[Required(ErrorMessage = "El campo 'centro de trabajo' es obligatorio")]
        public int CentroTrabajoId { get; set; }
        [Display(Name = "Centro de trabajo")]
        public CentroTrabajo CentroTrabajo { get; set; }

        [Required(ErrorMessage = "El campo 'motivo de solicitud' es obligatorio")]
        [Display(Name = "Motivo de solicitud")]
        [DataType(DataType.Text)]
        public string MotivoSolicitud { get; set; }

        //[Required(ErrorMessage = "El campo 'secretario de postgrado' es obligatorio")]
        public int SecretarioPostgId { get; set; }
        [Display(Name = "Secretario de postgrado")]
        public SecretarioPostg SecretarioPostg { get; set; }

        [Required(ErrorMessage = "El campo 'años de experiencia' es obligatorio")]
        [Display(Name = "Años de experiencia laboral")]
        public int AnnoExperienciaLaboral { get; set; }

        [Required(ErrorMessage = "El campo 'fecha de matriculación' es obligatorio")]
        [Display(Name = "Fecha de matriculación")]
        [DataType(DataType.Date)]
        public DateTime FechaMatricula { get; set; }

        //[Required(ErrorMessage = "El campo 'categoría docente' es obligatorio")]
        public int CategDocenteId { get; set; }
        [Display(Name ="Categoría docente")]
        public CategDocente CategDocente { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }

    }
}
