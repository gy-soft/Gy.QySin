using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Nombre { get; set; }
        public UsuarioRoles Rol { get; set; }
    }
    public class CrearCmdMnjr : IRequestHandler<CrearCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var entity = new Usuario(
                request.Nombre,
                request.Rol
            );

            await repos.Usuarios.AddAsync(entity, cancellationToken);
            
            return Unit.Value;
        }
    }
}