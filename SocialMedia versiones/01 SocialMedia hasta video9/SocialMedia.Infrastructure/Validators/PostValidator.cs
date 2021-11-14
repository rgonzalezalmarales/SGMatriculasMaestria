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
            //var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var c = new System.Globalization.CultureInfo("en-EN");
            //System.Threading.Thread.CurrentThread.CurrentCulture = c;
            System.Threading.Thread.CurrentThread.CurrentUICulture = c;

            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        }
    }
}
