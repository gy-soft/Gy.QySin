using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.ActualizarUsuario
{
    public class ActualizarUsuarioCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
    public class ActualizarUsuarioCmdMnjr : IRequestHandler<ActualizarUsuarioCmd>
    {
        private readonly IApplicationDbContext context;

        public ActualizarUsuarioCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(ActualizarUsuarioCmd request, CancellationToken cancellationToken)
        {
            var entity = await context.Usuarios
                .FindAsync(request.Clave, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            entity.Nombre = request.Nombre;
            entity.NombreCorto = request.NombreCorto;
            
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}