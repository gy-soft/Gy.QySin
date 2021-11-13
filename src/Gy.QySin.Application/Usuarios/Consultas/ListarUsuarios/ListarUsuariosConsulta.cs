using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Usuarios.Consultas.ListarUsuarios
{
    public class ListarUsuariosCon : IRequest<UsuariosVm>
    {
        public bool Activo { get; set; }
    }
    public class ListarUsuariosConMnjr : IRequestHandler<ListarUsuariosCon, UsuariosVm>
    {
        private readonly IApplicationDbContext context;

        public ListarUsuariosConMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<UsuariosVm> Handle(ListarUsuariosCon request, CancellationToken cancellationToken)
        {
            return new UsuariosVm
            {
                Roles = Enum.GetValues(typeof(UsuarioRoles))
                    .Cast<UsuarioRoles>()
                    .Select(r => new UsuarioRolDto { Value = (int)r, Name = r.ToString() })
                    .ToList(),
                Usuarios = await context.Usuarios
                    .Where(u => u.Activo == request.Activo)
                    .OrderBy(u => u.Nombre)
                    .Select(u => new UsuarioDto
                    {
                        Clave = u.Clave,
                        NombreCorto = u.NombreCorto,
                        Nombre = u.Nombre,
                        Activo = request.Activo
                    })
                    .AsNoTracking()
                    .ToListAsync()
            };
        }
    }
}