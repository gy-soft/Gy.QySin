using System.Threading.Tasks;
using Gy.QySin.Application.Platillos.Comandos.CrearPlatillo;
using Gy.QySin.Application.Platillos.ExtenderPlatillo;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class PlatillosController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CrearPlatilloCmd comando)
        {
            return await Mediator.Send(comando);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(ExtenderPlatilloCmd comando)
        {
            await Mediator.Send(comando);
            return NoContent();
        }
    }
}