using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Consultas.DetalleUsuario
{
    public class DetalleUsuarioCon : IRequest<UsuarioDto>
    {
        public string Clave { get; set; }
    }
    public class DetalleUsuarioConMnjr : IRequestHandler<DetalleUsuarioCon, UsuarioDto>
    {
        private readonly IApplicationDbContext context;

        public DetalleUsuarioConMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<UsuarioDto> Handle(DetalleUsuarioCon request, CancellationToken cancellationToken)
        {
            var entity = await context.Usuarios
                .FindAsync(request.Clave);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            return new UsuarioDto
            {
                Clave = entity.Clave,
                Nombre = entity.Nombre,
                NombreCorto = entity.NombreCorto,
                Activo = entity.Activo,
                Roles = entity.Roles
            };
        }
    }
}