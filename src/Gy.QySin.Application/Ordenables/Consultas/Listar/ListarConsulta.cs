using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Ordenables.Consultas.Listar
{
    public class ListarCon : IRequest<OrdenablesVm>
    {
        public OrdenableCategorias? Categoria { get; set; }
        public string PalabraClave { get; set; }
    }
    public class ListarConMnjr : IRequestHandler<ListarCon, OrdenablesVm>
    {
        private readonly IApplicationRepositories repos;

        public ListarConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<OrdenablesVm> Handle(ListarCon request, CancellationToken cancellationToken)
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
                        Categoria = o.Categoria
                    })
                    .ToListAsync()
            };
        }
    }
}