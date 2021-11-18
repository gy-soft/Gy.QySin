using System.Threading.Tasks;
using Gy.QySin.Application.Bebidas.Comandos;
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
    }
}