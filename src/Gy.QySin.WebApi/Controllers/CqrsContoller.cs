using System;
using System.Text.Json;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    [Route("api")]
    public class ComandosController : ApiControllerBase
    {
        [HttpGet("{entity}/{operation}")]
        public async Task<ActionResult> ConsultarAsync([FromRoute] string entity, [FromRoute] string operation)
        {
            string typeName = QueryAssemblyName(entity, operation);
            var tipoConsulta = Type.GetType(typeName);
            if (tipoConsulta is null)
            {
                throw new InvalidCommandException();
            }
            var consulta = Request.ContentLength.HasValue && Request.ContentLength.Value > 0 ?
                await JsonSerializer.DeserializeAsync(Request.Body, tipoConsulta)
                : Activator.CreateInstance(tipoConsulta);
            var response = await Mediator.Send(consulta);

            return new JsonResult(response);
        }
        [HttpPost("{entity}/{operation}")]
        public async Task<ActionResult> EjecutarAsync([FromRoute] string entity, [FromRoute] string operation)
        {
            string typeName = CommandAssemblyName(entity, operation);
            var tipoComando = Type.GetType(typeName);
            if (tipoComando is null)
            {
                throw new InvalidCommandException();
            }
            var comando = await JsonSerializer.DeserializeAsync(Request.Body, tipoComando);
            var response = await Mediator.Send(comando);
                
            return NoContent();
        }

        private static string CommandAssemblyName(string entity, string command)
        {
            return $"Gy.QySin.Application.{entity}.Comandos.{command}.{command}Cmd, Gy.QySin.Application";
        }
        private static string QueryAssemblyName(string entity, string query)
        {
            string queryName = $"{query}{entity}";
            return $"Gy.QySin.Application.{entity}.Consultas.{query}.{query}Con, Gy.QySin.Application";
        }
    }
}