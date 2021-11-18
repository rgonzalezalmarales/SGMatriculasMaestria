using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class BeforeTomorrowAttribute : ValidationAttribute
    {
        public BeforeTomorrowAttribute()
        {
        }

        public string GetErrorMessage() => $"La Fecha de graduado no puede ser superior a hoy";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var objeto que contiene la prop = (objeto original)validationContext.ObjectInstance; //Objeto 

            if ((DateTime)value > DateTime.Today)
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }
}
