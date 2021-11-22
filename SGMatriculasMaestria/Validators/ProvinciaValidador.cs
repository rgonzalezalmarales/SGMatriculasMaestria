using FluentValidation;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class ProvinciaValidador : AbstractValidator<Provincia>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public ProvinciaValidador()
        {
            string Pais = "nombre del pais";
            RuleFor(Provincia => Provincia.Nombre).
                NotEmpty().WithName(Pais).
                WithMessage(MessageNull).
                NotNull().WithName(Pais).
                WithMessage(MessageNull);
        }
    }
}
