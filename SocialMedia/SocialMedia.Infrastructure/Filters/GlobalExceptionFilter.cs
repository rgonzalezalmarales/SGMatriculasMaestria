using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //if(context.Exception.GetType() == typeof (BusinessException))
            if(context.Exception is BusinessException)
            {
                var exception = (BusinessException)context.Exception;
                var json = new
                {
                    title = "Bad Request",
                    status = (int)HttpStatusCode.BadRequest,
                    errors = new[] {exception.Message}
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
