using System.Threading.Tasks;
using Gy.QySin.Application.Usuarios.Comandos.CrearUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class UsuariosController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CrearUsuarioCmd comando)
        {
            return await Mediator.Send(comando);
        }
    }
}