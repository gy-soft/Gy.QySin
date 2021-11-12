using System.Collections.Generic;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Interfaces
{
    public interface IUsuario
    {
        string Clave { get; }
        string NombreCorto { get; }
        IEnumerable<UsuarioRoles> Roles { get; }
    }
}