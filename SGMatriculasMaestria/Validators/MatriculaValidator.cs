using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class MatriculaValidator : AbstractValidator<Matricula>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public MatriculaValidator()
        {
            string aspirante = "aspirante";
            RuleFor(Matricula => Matricula.AspiranteCI).
                    NotEmpty().WithName(aspirante).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(aspirante).
                    WithMessage(MessageNull);

            string MaestriaId = "maestría";
            RuleFor(Matricula => Matricula.MaestriaId).
                    NotEmpty().WithName(MaestriaId).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(MaestriaId).
                    WithMessage(MessageNull);

            string CentroTrabajoId = "centro de tabajo";
            RuleFor(Matricula => Matricula.CentroTrabajoId).
                    NotEmpty().WithName(CentroTrabajoId).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(CentroTrabajoId).
                    WithMessage(MessageNull);

            string CategDocenteId = "categoría docente";
            RuleFor(Matricula => Matricula.CategDocenteId).
                    NotEmpty().WithName(CategDocenteId).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(CategDocenteId).
                    WithMessage(MessageNull);

        }
    }
}
