using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gy.QySin.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FluentValidation.ValidationException e)
            {
                var response = new
                {
                    message = e.Message,
                    errors = e.Errors
                };
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        // TODO: Crear una excepción en la capa de Aplicación para formatear el error.
        private IReadOnlyDictionary<string, string> GetValidationErrors(IEnumerable<FluentValidation.Results.ValidationFailure> validatonErrors)
        {
            return validatonErrors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage);
        }
    }
}