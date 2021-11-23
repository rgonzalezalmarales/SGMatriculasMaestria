using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class MunicipioValidator : AbstractValidator<Municipio>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public MunicipioValidator()
        {
            string MunicipioId = "nombre";
            RuleFor(Municipio => Municipio.Nombre).
                NotEmpty().WithName(MunicipioId).
                WithMessage(MessageNull).
                NotNull().WithName(MunicipioId).
                WithMessage(MessageNull);

            string ProvinciaId = "nombre";
            RuleFor(Municipio => Municipio.ProvinciaId).
                NotEmpty().WithName(ProvinciaId).WithMessage(MessageNull).
                NotNull().WithName(ProvinciaId).WithMessage(MessageNull).
                GreaterThan(0).WithName(ProvinciaId).WithMessage(MessageNull);

        }

    }
}
