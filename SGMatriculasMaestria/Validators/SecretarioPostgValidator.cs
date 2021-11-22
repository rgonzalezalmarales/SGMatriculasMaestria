using FluentValidation;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class SecretarioPostgValidator: AbstractValidator<SecretarioPostg>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public SecretarioPostgValidator()
        {
            string Pais = "nombre";
            RuleFor(SecretarioPostg => SecretarioPostg.Nombre).
                NotEmpty().WithName(Pais).
                WithMessage(MessageNull).
                NotNull().WithName(Pais).
                WithMessage(MessageNull);
        }
    }
}
