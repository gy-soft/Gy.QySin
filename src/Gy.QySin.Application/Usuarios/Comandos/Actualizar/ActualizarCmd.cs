using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;
using System;

namespace Gy.QySin.Application.Usuarios.Comandos.Actualizar
{
    public class ActualizarCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
    }
    public class ActualizarCmdMnjr : IRequestHandler<ActualizarCmd>
    {
        private readonly IApplicationRepositories repos;

        public ActualizarCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<Unit> Handle(ActualizarCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Usuarios
                .GetAsync(new object[] { pk }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            Action<Usuario> updateAction = (usuario) =>
            {
                entity.Nombre = request.Nombre;
                entity.NombreCorto = request.NombreCorto;
            };

            await repos.Usuarios.UpdateAsync(entity, updateAction, cancellationToken);
            return Unit.Value;
        }
    }
}