using System.Threading.Tasks;
using Gy.QySin.Application.Usuarios.Comandos.ActualizarUsuario;
using Gy.QySin.Application.Usuarios.Comandos.CrearUsuario;
using Gy.QySin.Application.Usuarios.Comandos.DesactivarUsuario;
using Gy.QySin.Application.Usuarios.Consultas.ListarUsuarios;
using Microsoft.AspNetCore.Mvc;

namespace Gy.QySin.WebApi.Controllers
{
    public class UsuariosController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UsuariosVm>> GetAll([FromQuery] ListarUsuariosCon consulta)
        {
            return await Mediator.Send(consulta);
        }
        [HttpPost]
        public async Task<ActionResult<string>> Create(CrearUsuarioCmd comando)
        {
            return await Mediator.Send(comando);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, ActualizarUsuarioCmd comando)
        {
            comando.Clave = id;
            await Mediator.Send(comando);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Update(string id)
        {
            var comando = new DesactivarUsuarioCmd
            {
                Clave = id
            };
            await Mediator.Send(comando);
            return NoContent();
        }
    }
}