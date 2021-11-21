using System.Threading.Tasks;
using Gy.QySin.Application.Comandas.Comandos.CrearComanda;
using Gy.QySin.Application.Comandas.Comandos.ExtenderComanda;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class ComandasController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CrearComandaCmd comando)
        {
            return await Mediator.Send(comando);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, ExtenderComandaCmd comando)
        {
            comando.NumeroComanda = id;
            await Mediator.Send(comando);
            return NoContent();
        }
    }
}