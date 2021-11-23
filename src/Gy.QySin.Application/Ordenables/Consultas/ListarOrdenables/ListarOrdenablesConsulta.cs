using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Ordenables.Consultas.ListarOrdenables
{
    public class ListarOrdenablesCon : IRequest<OrdenablesVm>
    {
        public OrdenableCategorias? Categoria { get; set; }
        public string PalabraClave { get; set; }
    }
    public class ListarOrdenablesConMnjr : IRequestHandler<ListarOrdenablesCon, OrdenablesVm>
    {
        private readonly IApplicationRepositories repos;

        public ListarOrdenablesConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<OrdenablesVm> Handle(ListarOrdenablesCon request, CancellationToken cancellationToken)
        {
            return new OrdenablesVm
            {
                Categorias = Enum.GetValues(typeof(OrdenableCategorias))
                    .Cast<OrdenableCategorias>()
                    .Select(c => new OrdenableCategoriaDto { Value = (int)c, Name = c.ToString() })
                    .ToList(),
                Ordenables = await repos.Ordenables
                    .AsQueryable()
                    .Where(o => 
                        string.IsNullOrWhiteSpace(request.PalabraClave)
                        || o.Nombre.ToUpper().Contains(request.PalabraClave.ToUpper())
                    )
                    .Where(o => !request.Categoria.HasValue || o.Categoria == request.Categoria)
                    .Select(o => new OrdenableDto
                    {
                        Clave = o.Clave.ToString(),
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