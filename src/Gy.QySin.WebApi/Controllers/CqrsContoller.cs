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
            var consulta = await JsonSerializer.DeserializeAsync(Request.Body, tipoConsulta);
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
    }
}