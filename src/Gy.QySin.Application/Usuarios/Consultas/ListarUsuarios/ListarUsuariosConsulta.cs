using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Consultas.ListarUsuarios
{
    public class ListarUsuariosConsulta : IRequest<UsuariosVm>
    {
        public bool Activo { get; set; }
    }
    public class ListarUsuariosConsultaManejador : IRequestHandler<ListarUsuariosConsulta, UsuariosVm>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public ListarUsuariosConsultaManejador(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UsuariosVm> Handle(ListarUsuariosConsulta request, CancellationToken cancellationToken)
        {
            return new UsuariosVm
            {
                Roles = Enum.GetValues(typeof(UsuarioRoles))
                    .Cast<UsuarioRoles>()
                    .Select(r => new UsuarioRolDto { Value = (int)r, Name = r.ToString() })
                    .ToList(),
                Usuarios = await context.Usuarios
                    .Where(u => u.Activo)
                    .AsNoTracking()
                    .ProjectTo<UsuarioDto>(mapper.ConfigurationProvider)
                    .OrderBy(u => u.Nombre)
                    .ToListAsync()
            };
        }
    }
}