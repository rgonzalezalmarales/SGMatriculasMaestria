using FluentValidation;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class AspiranteValidator : AbstractValidator<Aspirante>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio";}
        private string RegLastName { get => "^(([A-Z][a-záéíóúñü]{1,})(( [A-Z][a-záéíóúñ]{0,})*|( [a-z]{2} ([A-Z][a-záéíóúñ]{1,}))))$"; }
        public AspiranteValidator()
        {
            
            RuleFor(Aspirante => Aspirante.CI).
                NotEmpty().WithName("carnet").WithMessage(MessageNull).
                NotEmpty().WithName("carnet").WithMessage(MessageNull).
                Matches("[0-9]{11}").
                WithMessage("Valor correcto: 11 dígitos");

            RuleFor(Aspirante => Aspirante.Nombre).
                Matches("^(([A-Z][a-záéíóúñü]{2,})( [A-Z][a-záéíóúñ]{2,}){0,2})$").
                WithMessage("Solo letras Ej: Ana");
            
            RuleFor(Aspirante => Aspirante.PrimerApellido).
                Matches(RegLastName).WithMessage("Solo letras Ej: Pérez");
            
            RuleFor(Aspirante => Aspirante.SegundoApellido).
                Matches(RegLastName).WithMessage("Solo letras Ej: Pérez");

            RuleFor(Aspirante => Aspirante.Email).
                EmailAddress().WithMessage("Valor correcto: correo electrónico");

            RuleFor(Aspirante => Aspirante.FechaGraduacion).
                LessThan(DateTime.Now).
                WithMessage("No se permiten fechas mayores que hoy");

            RuleFor(Aspirante => Aspirante.PaisId).
                NotNull().WithMessage("El campo 'pais' es obligatorio");

            RuleFor(Aspirante => Aspirante.MunicipioId).
                NotNull().WithMessage("El campo 'municipio' es obligatorio");

            RuleFor(Aspirante => Aspirante.ProvinciaId).
                NotNull().WithMessage("El campo 'provincia' es obligatorio");
        }
    }
}
