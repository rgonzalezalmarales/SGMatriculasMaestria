using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.DTOs
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        public int FacultadId { get; set; }

        [Display(Name = "Aspirante (CI)")]
        public string AspiranteCI { get; set; }
        public Aspirante Aspirante { get; set; }

        [Display(Name = "Maestría")]        
        public int MaestriaId { get; set; }
        public Maestria Maestria { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha de culminación")]
        [DataType(DataType.Date)]
        public DateTime FechaCulminacion { get; set; }

        [Display(Name = "Centro de trabajo")]
        public int CentroTrabajoId { get; set; }
        public CentroTrabajo CentroTrabajo { get; set; }

        [Display(Name = "Motivo de solicitud")]        
        [DataType(DataType.Text)]
        public string MotivoSolicitud { get; set; }

        [Display(Name = "Secretario de postgrado")]
        public int SecretarioPostgId { get; set; }
        public SecretarioPostg SecretarioPostg { get; set; }

        [Display(Name = "Años de experiencia laboral")]
        public int AnnoExperienciaLaboral { get; set; }

        [Display(Name = "Fecha de matriculación")]
        [DataType(DataType.Date)]
        
        public DateTime FechaMatricula { get; set; }

        [Display(Name = "Categoría docente")]        
        public int CategDocenteId { get; set; }
        public CategDocente CategDocente { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }       
    }
}


/*public int Id { get; set; }

       public int FacultadId { get; set; }

       //
       public string AspiranteCI { get; set; }

       public Aspirante Aspirante { get; set; }

       //
       //[Display(Name = "Maestría")]
       public int MaestriaId { get; set; }     
       public Maestria Maestria { get; set; }

       public DateTime FechaActual { get; set; }

       //
       //
       //[DataType(DataType.Date)]

       public DateTime FechaInicio { get; set; }

       //
       //
       //
       public DateTime FechaCulminacion { get; set; }

       //
       public int CentroTrabajoId { get; set; }
       //[Display(Name = "Centro de trabajo")]
       public CentroTrabajo CentroTrabajo { get; set; }

       //
       public string MotivoSolicitud { get; set; }

       //
       public int SecretarioPostgId { get; set; }
       //
       public SecretarioPostg SecretarioPostg { get; set; }

       //
       //
       public int AnnoExperienciaLaboral { get; set; }

       //
       //
       public DateTime FechaMatricula { get; set; }

       //
       public int CategDocenteId { get; set; }
       //
       public CategDocente CategDocente { get; set; }

       public DateTime Creatat { get; set; }
       public DateTime Modifiat { get; set; }*/
