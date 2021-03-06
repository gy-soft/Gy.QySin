using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Usuarios.Consultas.Listar
{
    public class ListarCon : IRequest<UsuariosVm>
    {
        public bool? Activo { get; set; }
        public UsuarioRoles? Rol { get; set; }
    }
    public class ListarConMnjr : IRequestHandler<ListarCon, UsuariosVm>
    {
        private readonly IApplicationRepositories repos;

        public ListarConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<UsuariosVm> Handle(ListarCon request, CancellationToken cancellationToken)
        {
            return new UsuariosVm
            {
                Roles = Enum.GetValues(typeof(UsuarioRoles))
                    .Cast<UsuarioRoles>()
                    .Select(r => new UsuarioRolDto { Value = (int)r, Name = r.ToString() })
                    .ToList(),
                Usuarios = await repos.Usuarios
                    .AsQueryable()
                    .Where(u => !request.Activo.HasValue || u.Activo == request.Activo)
                    .Where(u => !request.Rol.HasValue || u.Roles.Contains(request.Rol.Value))
                    .OrderBy(u => u.Nombre)
                    .Select(u => new UsuarioDto
                    {
                        Clave = u.Clave.ToString(),
                        NombreCorto = u.NombreCorto,
                        Nombre = u.Nombre,
                        Activo = u.Activo
                    })
                    .ToListAsync()
            };
        }
    }
}