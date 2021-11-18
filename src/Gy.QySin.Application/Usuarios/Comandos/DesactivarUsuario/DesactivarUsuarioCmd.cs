using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Comandos.DesactivarUsuario
{
    public class DesactivarUsuarioCmd : IRequest
    {
        public string Clave { get; set; }
    }
    public class DesactivarUsuarioCmdMnjr : IRequestHandler<DesactivarUsuarioCmd>
    {
        private readonly IApplicationDbContext context;

        public DesactivarUsuarioCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DesactivarUsuarioCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Usuarios
                .FindAsync(pk);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            entity.Roles = null;
            entity.Activo = false;
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}