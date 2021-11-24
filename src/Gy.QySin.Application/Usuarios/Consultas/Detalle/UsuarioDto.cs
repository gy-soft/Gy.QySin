using System.Collections.Generic;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Application.Usuarios.Consultas.Detalle
{
    public class DetalleDto
    {
        public string Clave { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<UsuarioRoles> Roles { get; set; }
    }
}