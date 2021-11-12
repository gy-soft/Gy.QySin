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

namespace Gy.QySin.Application.Consultas.ListarOrdenables
{
    public class ListarOrdenablesConsulta : IRequest<OrdenablesVm>
    {
        public OrdenableCategorias? Categoria { get; set; }
        public string PalabraClave { get; set; }
    }
    public class ListarOrdenablesConsultaManejador : IRequestHandler<ListarOrdenablesConsulta, OrdenablesVm>
    {
        private readonly IApplicationDbContext contex;
        private readonly IMapper mapper;

        public ListarOrdenablesConsultaManejador(IApplicationDbContext contex, IMapper mapper)
        {
            this.contex = contex;
            this.mapper = mapper;
        }
        public async Task<OrdenablesVm> Handle(ListarOrdenablesConsulta request, CancellationToken cancellationToken)
        {
            return new OrdenablesVm
            {
                Categorias = Enum.GetValues(typeof(OrdenableCategorias))
                .Cast<OrdenableCategorias>()
                .Select(c => new OrdenableCategoriaDto { Value = (int)c, Name = c.ToString() })
                .ToList(),
                Ordenables = await contex.Ordenables
                .Where(o => string.IsNullOrWhiteSpace(request.PalabraClave) || o.Nombre.Contains(request.PalabraClave))
                .AsNoTracking()
                .ProjectTo<OrdenableDto>(mapper.ConfigurationProvider)
                .ToListAsync()
            };
        }
    }
}