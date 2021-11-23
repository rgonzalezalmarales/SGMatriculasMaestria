using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class CentroTrabajoValidator: AbstractValidator<CentroTrabajo>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public CentroTrabajoValidator()
        {
            string centroTrabajoName = "nombre";
            RuleFor(CentroTrabajo => CentroTrabajo.Nombre).
                NotEmpty().WithName(centroTrabajoName).WithMessage(MessageNull).
                NotNull().WithName(centroTrabajoName).WithMessage(MessageNull);

            string departamentoName = "departamento";
            RuleFor(CentroTrabajo => CentroTrabajo.Departamento).
                NotEmpty().WithName(departamentoName).WithMessage(MessageNull).
                NotNull().WithName(departamentoName).WithMessage(MessageNull);

            string direccionName = "dirección";
            RuleFor(CentroTrabajo => CentroTrabajo.Direccion).
                NotEmpty().WithName(direccionName).WithMessage(MessageNull).
                NotNull().WithName(direccionName).WithMessage(MessageNull);

            string provinciaIdName = "provincia";
            RuleFor(CentroTrabajo => CentroTrabajo.ProvinciaId).
                NotEmpty().WithName(provinciaIdName).WithMessage(MessageNull).
                NotNull().WithName(provinciaIdName).WithMessage(MessageNull).
                GreaterThan(0).WithName(provinciaIdName).WithMessage(MessageNull);

            string municipioIdName = "municipio";
            RuleFor(CentroTrabajo => CentroTrabajo.MunicipioId).
                NotEmpty().WithName(municipioIdName).WithMessage(MessageNull).
                NotNull().WithName(municipioIdName).WithMessage(MessageNull).
                GreaterThan(0).WithName(municipioIdName).WithMessage(MessageNull);
        }
    }
}
