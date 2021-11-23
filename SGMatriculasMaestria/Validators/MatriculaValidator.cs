using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.Data;
using SGMatriculasMaestria.DTOs;
using SGMatriculasMaestria.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Validators
{
    public class MatriculaValidator : AbstractValidator<MatriculaDto>
    {
        private readonly ApplicationDbContext _context;
        private string MessageNull { get => "El campo '{PropertyName}' es obligatorio"; }
        public MatriculaValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.FechaInicio).
                NotEmpty().WithName("fecha de inicio").WithMessage(MessageNull).
                Must(FechaMayorHoy).WithMessage("La fecha de inicio debe ser mayor o igual que la actual");

            //[Required(ErrorMessage = "El campo 'fecha de matriculación' es obligatorio")]
            RuleFor(v => v.FechaCulminacion).            
            NotEmpty().WithName("fecha de culminación").WithMessage(MessageNull).
            Must(
                 (model, FechaCulminacion) =>
                 {
                     return  model.FechaInicio < FechaCulminacion;
                 }
            ).WithMessage("La fecha de culminación no puede ser menor o igual que la fecha de inicio");

            
            RuleFor(x => x.MotivoSolicitud).
                NotEmpty().WithName("motivo de solicitud").WithMessage(MessageNull);

            
            

            //[Required(ErrorMessage = "El campo 'años de experiencia' es obligatorio")]
            RuleFor(x => x.AnnoExperienciaLaboral).
                NotEmpty().WithName("años de experiencia").WithMessage(MessageNull);           
            

            string aspirante = "aspirante";
            RuleFor(Matricula => Matricula.AspiranteCI).
                    NotEmpty().WithName(aspirante).
                    WithMessage(MessageNull).
                    NotNull().
                    WithName(aspirante).
                    WithMessage(MessageNull).
                    MustAsync(ExisteAspirante).WithMessage("El carnet de identidad no esta asociado a ningún aspirante del registro");

            string MaestriaId = "maestría";
            RuleFor(Matricula => Matricula.MaestriaId).
                NotEmpty().WithName(MaestriaId).WithMessage(MessageNull).
                NotNull().WithName(MaestriaId).WithMessage(MessageNull).
                GreaterThan(0).WithName(MaestriaId).WithMessage(MessageNull);

            //[Required(ErrorMessage = "El campo 'centro de trabajo' es obligatorio")]
            string CentroTrabajoId = "centro de tabajo";
            RuleFor(Matricula => Matricula.CentroTrabajoId).
                NotEmpty().WithName(CentroTrabajoId).WithMessage(MessageNull).
                NotNull().WithName(CentroTrabajoId).WithMessage(MessageNull).
                GreaterThan(0).WithName(CentroTrabajoId).WithMessage(MessageNull);

            //[Required(ErrorMessage = "El campo 'categoría docente' es obligatorio")]
            string CategDocenteId = "categoría docente";
            RuleFor(Matricula => Matricula.CategDocenteId).
                NotEmpty().WithName(CategDocenteId).WithMessage(MessageNull).
                NotNull().WithName(CategDocenteId).WithMessage(MessageNull).
                GreaterThan(0).WithName(CategDocenteId).WithMessage(MessageNull);

            string FacultadId = "facultad";
            RuleFor(Matricula => Matricula.FacultadId).
                NotEmpty().WithName(FacultadId).WithMessage(MessageNull).
                NotNull().WithName(FacultadId).WithMessage(MessageNull).
                GreaterThan(0).WithName(FacultadId).WithMessage(MessageNull);

            string SecretarioPostgId = "secretario de postgrado";
            RuleFor(Matricula => Matricula.SecretarioPostgId).
                NotEmpty().WithName(SecretarioPostgId).WithMessage(MessageNull).
                NotNull().WithName(SecretarioPostgId).WithMessage(MessageNull).
                GreaterThan(0).WithName(SecretarioPostgId).WithMessage(MessageNull);

        }

      

        //https://stackoverflow.com/questions/17155536/have-fluentvalidation-call-a-function-with-multiple-parameters
        /*RuleFor(v => v.UserId).MustAsync(
            async (model, userId, cancellation) =>
           {
            return await IsValid(model.PromoCode, userId, cancellation);
        }
         ).WithMessage("{PropertyName} message.");


        private async Task<bool> IsUniqueUserNameAsync(string promoCode, string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }*/

        private bool FechaMayorHoy(DateTime? dateTime)
        {
            return dateTime is not null && dateTime > DateTime.Now;
        }

        private async Task<bool> ExisteAspirante(string aspiranteId, CancellationToken arg2)
        {
            var aspirante = await _context.Aspirantes.FirstOrDefaultAsync(x => x.CI == aspiranteId);
            return aspirante is not null;
        }

        
    }
}
