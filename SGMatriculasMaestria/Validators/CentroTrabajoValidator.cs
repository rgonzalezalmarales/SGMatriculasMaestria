using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class CentroTrabajoValidator: AbstractValidator<CentroTrabajo>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public CentroTrabajoValidator()
        {
            string CentroTrabajoName = "nombre";
            RuleFor(CentroTrabajo => CentroTrabajo.Nombre).
                NotEmpty().WithName(CentroTrabajoName).
                WithMessage(MessageNull).
                NotNull().WithName(CentroTrabajoName).
                WithMessage(MessageNull);

            string Departamento = "departamento";
            RuleFor(CentroTrabajo => CentroTrabajo.Departamento).
                NotEmpty().WithName(Departamento).
                WithMessage(MessageNull).
                NotNull().WithName(Departamento).
                WithMessage(MessageNull);

            //string Departamento = "departamento";
            RuleFor(CentroTrabajo => CentroTrabajo.Direccion).
                NotEmpty().
                //WithName(Departamento).
                WithMessage(MessageNull).
                NotNull().
                //WithName(Departamento).
                WithMessage(MessageNull);

            string ProvinciaId = "provincia";
            RuleFor(CentroTrabajo => CentroTrabajo.ProvinciaId).
                NotEmpty().WithName(ProvinciaId).
                WithMessage(MessageNull).
                NotNull().
                WithName(ProvinciaId).
                WithMessage(MessageNull);

            string MunicipioId = "municipio";
            RuleFor(CentroTrabajo => CentroTrabajo.MunicipioId).
                NotEmpty().WithName(MunicipioId).
                WithMessage(MessageNull).
                NotNull().WithName(MunicipioId).
                WithMessage(MessageNull);
        }
    }
}
