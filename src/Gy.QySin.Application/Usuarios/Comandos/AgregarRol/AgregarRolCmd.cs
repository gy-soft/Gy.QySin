using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using MediatR;
using System;

namespace Gy.QySin.Application.Usuarios.Comandos.AgregarRol
{
    public class AgregarRolCmd : IRequest
    {
        public string Clave { get; set; }
        public UsuarioRoles Rol { get; set; }
    }
    public class AgregarRolCmdMnjr : IRequestHandler<AgregarRolCmd>
    {
        private readonly IApplicationRepositories repos;

        public AgregarRolCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(AgregarRolCmd request, CancellationToken cancellationToken)
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
                usuario.Activo = true;
                usuario.AgregarRol(request.Rol);
            };

            await repos.Usuarios.UpdateAsync(entity, updateAction, cancellationToken);

            return Unit.Value;
        }
    }
}