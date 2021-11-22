using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class MaestriaValidator: AbstractValidator<Maestria>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public MaestriaValidator()
        {
            string facultad = "facultad";
            RuleFor(Maestrias => Maestrias.FacultadId).
                    NotEmpty().WithName(facultad).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(facultad).
                    WithMessage(MessageNull);
        }
    }
}
