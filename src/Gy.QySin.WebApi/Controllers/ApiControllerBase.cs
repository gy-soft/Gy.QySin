using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Gy.QySin.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null;
        protected ISender Mediator => _mediator ??= HttpContext
            .RequestServices
            .GetRequiredService<ISender>();

        public static string CommandAssemblyName(string entity, string command)
        {
            string commandName = $"{command}{entity}";
            return $"Gy.QySin.Application.{entity}.Comandos.{commandName}.{commandName}Cmd, Gy.QySin.Application";
        }
        public static string QueryAssemblyName(string entity, string query)
        {
            string queryName = $"{query}{entity}";
            return $"Gy.QySin.Application.{entity}.Consultas.{queryName}.{queryName}Con, Gy.QySin.Application";
        }
    }
}