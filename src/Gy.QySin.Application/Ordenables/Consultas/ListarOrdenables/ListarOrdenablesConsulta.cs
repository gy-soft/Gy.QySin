using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public ListarOrdenablesConsultaManejador(IApplicationDbContext contex)
        {
            this.contex = contex;
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
                    .Where(o => !request.Categoria.HasValue || o.Categoria == request.Categoria)
                    .Select(o => new OrdenableDto
                    {
                        Clave = o.Clave,
                        Nombre = o.Nombre,
                        Precio = o.Precio,
                        Categoria = o.Categoria
                    })
                    .AsNoTracking()
                    .ToListAsync()
            };
        }
    }
}