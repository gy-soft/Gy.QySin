using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Comandos.CrearUsuario
{
    public class CrearUsuarioCmd : IRequest<string>
    {
        public string Nombre { get; set; }
        public UsuarioRoles Rol { get; set; }
    }
    public class CrearUsuarioCmdManejador : IRequestHandler<CrearUsuarioCmd, string>
    {
        private readonly IApplicationDbContext context;

        public CrearUsuarioCmdManejador(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(CrearUsuarioCmd request, CancellationToken cancellationToken)
        {
            var entity = new Usuario(
                request.Nombre,
                request.Rol
            );

            await context.Usuarios.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return entity.Clave;
        }
    }
}