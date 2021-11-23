using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Consultas.DetalleUsuario
{
    public class DetalleUsuarioCon : IRequest<DetalleUsuarioDto>
    {
        public string Clave { get; set; }
    }
    public class DetalleUsuarioConMnjr : IRequestHandler<DetalleUsuarioCon, DetalleUsuarioDto>
    {
        private readonly IApplicationRepositories repos;

        public DetalleUsuarioConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<DetalleUsuarioDto> Handle(DetalleUsuarioCon request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Usuarios
                .GetAsync(pk, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            return new DetalleUsuarioDto
            {
                Clave = entity.Clave.ToString(),
                Nombre = entity.Nombre,
                NombreCorto = entity.NombreCorto,
                Activo = entity.Activo,
                Roles = entity.Roles
            };
        }
    }
}