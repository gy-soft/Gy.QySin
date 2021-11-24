using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;
using System;

namespace Gy.QySin.Application.Usuarios.Comandos.Desactivar
{
    public class DesactivarCmd : IRequest
    {
        public string Clave { get; set; }
    }
    public class DesactivarCmdMnjr : IRequestHandler<DesactivarCmd>
    {
        private readonly IApplicationRepositories repos;

        public DesactivarCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<Unit> Handle(DesactivarCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Usuarios
                .GetAsync(pk, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }
            Action<Usuario> updateAction = (usuario) =>
            {
                usuario.Roles = null;
                usuario.Activo = false;
            };

            await repos.Usuarios.UpdateAsync(entity, updateAction, cancellationToken);

            return Unit.Value;
        }
    }
}