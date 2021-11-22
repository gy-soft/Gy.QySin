using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
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
    public class CrearUsuarioCmdMnjr : IRequestHandler<CrearUsuarioCmd, string>
    {
        private readonly IApplicationRepositories repos;

        public CrearUsuarioCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<string> Handle(CrearUsuarioCmd request, CancellationToken cancellationToken)
        {
            var entity = new Usuario(
                request.Nombre,
                request.Rol
            );

            var id = await repos.Usuarios.AddAsync(entity, cancellationToken);
            
            return id.ToString();
        }
    }
}