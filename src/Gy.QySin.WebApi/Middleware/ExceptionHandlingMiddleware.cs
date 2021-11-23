using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Gy.QySin.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private const string STATUS_500_MESSAGE = "Ocurrió un error inesperado procesando la petición.";
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (RequestValidationException e)
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
            catch (InvalidCommandException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (System.Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(STATUS_500_MESSAGE);
            }
        }
    }
}