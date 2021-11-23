using FluentValidation;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class CesValidator : AbstractValidator<Ces>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }

        public CesValidator()
        {
            RuleFor(Ces => Ces.Nombre).
                NotEmpty().
                WithMessage(MessageNull).
                NotNull().
                WithMessage(MessageNull);

            string Descripcion = "descripción";
            RuleFor(Ces => Ces.Descripcion).
                    NotEmpty().WithName(Descripcion).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(Descripcion).
                    WithMessage(MessageNull);

            string ProvinciaId = "provincia";
            RuleFor(Ces => Ces.ProvinciaId).
                NotEmpty().WithName(ProvinciaId).WithMessage(MessageNull).
                NotNull().WithName(ProvinciaId).WithMessage(MessageNull).
                GreaterThan(0).WithName(ProvinciaId).WithMessage(MessageNull);

            string MunicipioId = "municipio";
            RuleFor(Ces => Ces.MunicipioId).
                NotEmpty().WithName(MunicipioId).WithMessage(MessageNull).
                NotNull().WithName(MunicipioId).WithMessage(MessageNull).
                GreaterThan(0).WithName(MunicipioId).WithMessage(MessageNull);

        }

        
    }
}
