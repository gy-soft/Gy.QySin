using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Comandos.ExtenderUsuario
{
    public class ExtenderUsuarioCmd : IRequest
    {
        public string Clave { get; set; }
        public UsuarioRoles Rol { get; set; }
    }
    public class ExtenderUsuarioCmdMnjr : IRequestHandler<ExtenderUsuarioCmd>
    {
        private readonly IApplicationDbContext context;

        public ExtenderUsuarioCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ExtenderUsuarioCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Usuarios
                .FindAsync(pk);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            entity.Activo = true;
            if (entity.Roles is null)
            {
                entity.Roles = new List<UsuarioRoles>()
                {
                    request.Rol
                };
            }
            else if (!entity.Roles.Contains(request.Rol))
            {
                entity.Roles.Add(request.Rol);
            }
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}