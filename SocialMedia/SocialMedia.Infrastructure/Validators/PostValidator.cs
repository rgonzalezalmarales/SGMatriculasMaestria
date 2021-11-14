using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            //Esto no viene en el curso
            //Detecte que el idioma de FluenteValidation depende de culture,
            //por eso lo cambio a espanol de la forma que encontre y autmaticamente se cambia a espanol el mensaje de error
            //En mi caso a ingles porque como la pc está en espanol automaticamente los mensajes estan en es-Es.

            //var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var c = new System.Globalization.CultureInfo("en-EN");
            System.Threading.Thread.CurrentThread.CurrentCulture = c;
            System.Threading.Thread.CurrentThread.CurrentUICulture = c;

            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        }
        //Cuando necesitamos setear nuestro propio mensaje se hace de esta forma
        /*public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("La descripción no puede ser nula");

            RuleFor(post => post.Description)
                .Length(10, 500)
                .WithMessage("La longitud de la descripción de estar entre 10 y 500 caracteres");

        }*/
    }
}
