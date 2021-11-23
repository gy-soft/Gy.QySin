using System;
using System.Text.Json;
using System.Threading.Tasks;
using Gy.QySin.Application.Bebidas.Comandos.ExtenderBebida;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class ComandosController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> EjecutarAsync(PeticiónComando petición)
        {
            var someType = typeof(ExtenderBebidaCmd);
            var str = someType.AssemblyQualifiedName;
            
            string typeName = petición.NombreTipo();
            var tipoComando = Type.GetType(typeName);
            if (tipoComando is null)
            {
                throw new InvalidCommandException();
            }
            var comando = JsonSerializer.Deserialize(petición.Valor, tipoComando);
            var response = await Mediator.Send(comando);
            if (response is null)
            {
                return NoContent();
            }
            return Content(JsonSerializer.Serialize(response), "application/json");
        }
    }
}