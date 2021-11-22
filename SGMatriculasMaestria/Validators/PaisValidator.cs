using FluentValidation;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class PaisValidator : AbstractValidator<Pais>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public PaisValidator()
        {
            string Pais = "nombre del pais";
            RuleFor(Pais => Pais.Nombre).
                NotEmpty().WithName(Pais).
                WithMessage(MessageNull).
                NotNull().WithName(Pais).
                WithMessage(MessageNull);
        }
    }
}
