using System.Threading.Tasks;
using Gy.QySin.Application.Bebidas.Comandos.CrearBebida;
using Gy.QySin.Application.Bebidas.Comandos.ExtenderBebida;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class BebidasController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CrearBebidaCmd comando)
        {
            return await Mediator.Send(comando);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(string id, ExtenderBebidaCmd comando)
        {
            comando.Clave = id;
            await Mediator.Send(comando);
            return NoContent();
        }
    }
}