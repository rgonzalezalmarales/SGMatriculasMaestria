using FluentValidation;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Validators
{
    public class CategDocenteValidator: AbstractValidator<CategDocente>
    {
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }

        public CategDocenteValidator()
        {
            RuleFor(CategDocente => CategDocente.Nombre).
                NotEmpty().
                WithMessage(MessageNull).
                NotNull().
                WithMessage(MessageNull);
                /*Matches("^(([A-Z][a-záéíóúñü]{2,})( [A-Z][a-záéíóúñü]{2,}){0,2})$").
                WithMessage("El campo '{PropertyName}' no cumple con los");*/
        }
    }
}
