using System.Collections.Generic;

namespace Gy.QySin.Application.Consultas.ListarUsuarios
{
    public class UsuariosVm
    {
        public IList<UsuarioRolDto> Roles { get; set; } = new List<UsuarioRolDto>();
        public IList<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
    }
}