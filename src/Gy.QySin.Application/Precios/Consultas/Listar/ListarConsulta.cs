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
            return await repos.PrecioOrdenables
                .AsQueryable()
                .Join(
                    repos.Ordenables.AsQueryable()
                    .Where(o => string.IsNullOrWhiteSpace(request.PalabraClave)
                    || o.Nombre.Contains(request.PalabraClave))
                    .Where(o => !request.Categoria.HasValue || o.Categoria == request.Categoria),
                    p => p.Clave,
                    o => o.Clave,
                    (precio, ordenable) => new PrecioOrdenableDto
                    {
                        Clave = precio.Clave.ToString(),
                        Precio = precio.Precio,
                        FechaInicio = precio.FechaInicio,
                        FechaFin = precio.FechaFin,
                        Nombre = ordenable.Nombre,
                        Categoria = ordenable.Categoria
                    })
                    .ToListAsync(cancellationToken);
        }
    }
}