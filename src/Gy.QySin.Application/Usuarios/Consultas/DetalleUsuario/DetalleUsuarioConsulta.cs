using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
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
        private readonly IApplicationDbContext context;

        public DetalleUsuarioConMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<DetalleUsuarioDto> Handle(DetalleUsuarioCon request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Usuarios
                .FindAsync(pk);

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