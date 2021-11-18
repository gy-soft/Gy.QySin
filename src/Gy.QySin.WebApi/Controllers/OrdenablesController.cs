using System.Threading.Tasks;
using Gy.QySin.Application.Ordenables.Consultas.ListarOrdenables;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class OrdenablesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<OrdenablesVm>> GetAll([FromQuery] ListarOrdenablesCon consulta)
        {
            return await Mediator.Send(consulta);
        }
    }
}