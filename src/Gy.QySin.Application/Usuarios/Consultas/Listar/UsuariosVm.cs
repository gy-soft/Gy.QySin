using System.Collections.Generic;

namespace Gy.QySin.Application.Usuarios.Consultas.Listar
{
    public class UsuariosVm
    {
        public IList<UsuarioRolDto> Roles { get; set; } = new List<UsuarioRolDto>();
        public IList<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
    }
}