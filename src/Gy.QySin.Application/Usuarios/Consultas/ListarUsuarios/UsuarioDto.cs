using Gy.QySin.Application.Common.Mappings;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.Application.Consultas.ListarUsuarios
{
    public class UsuarioDto : IMapFrom<Usuario>
    {
        public string Clave { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}