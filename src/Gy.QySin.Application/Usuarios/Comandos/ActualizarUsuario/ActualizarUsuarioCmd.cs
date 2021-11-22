using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Comandos.ActualizarUsuario
{
    public class ActualizarUsuarioCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
    public class ActualizarUsuarioCmdMnjr : IRequestHandler<ActualizarUsuarioCmd>
    {
        private readonly IApplicationRepositories repos;

        public ActualizarUsuarioCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<Unit> Handle(ActualizarUsuarioCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Usuarios
                .GetAsync(pk, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            entity.Nombre = request.Nombre;
            entity.NombreCorto = request.NombreCorto;
            
            await repos.Usuarios.AddAsync(entity, cancellationToken);
            return Unit.Value;
        }
    }
}