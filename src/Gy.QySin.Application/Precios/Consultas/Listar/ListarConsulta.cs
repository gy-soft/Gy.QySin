using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Precios.Consultas.Listar
{
    public class ListarCon : IRequest<List<PrecioOrdenableDto>>
    {
        public OrdenableCategorias? Categoria { get; set; }
        public string PalabraClave { get; set; }
    }
    public class ListarConMnjr : IRequestHandler<ListarCon, List<PrecioOrdenableDto>>
    {
        private readonly IApplicationRepositories repos;

        public ListarConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<List<PrecioOrdenableDto>> Handle(ListarCon request, CancellationToken cancellationToken)
        {
            return await repos.PrecioOrdenablesUi
                .AsQueryable()
                .Where(p => string.IsNullOrWhiteSpace(request.PalabraClave)
                    || p.Nombre.Contains(request.PalabraClave))
                .Where(p => !request.Categoria.HasValue || p.Categoria == request.Categoria)
                .Select(p => new PrecioOrdenableDto
                {
                    Clave = p.Clave.ToString(),
                    Precio = p.Precio,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    Nombre = p.Nombre,
                    Categoria = p.Categoria
                })
                .ToListAsync(cancellationToken);
        }
    }
}