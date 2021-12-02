using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
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
                Bebidas = await repos.Bebidas
                    .AsQueryable()
                    .Where(b => !request.Categoria.HasValue || request.Categoria == OrdenableCategorias.Bebidas)
                    .Where(b => string.IsNullOrWhiteSpace(request.PalabraClave)
                        || b.Nombre.Contains(request.PalabraClave))
                    .Select(b => new BebidaDto
                    {
                        Clave = b.Clave.ToString(),
                        Nombre = b.Nombre,
                        Contenido = b.Contenido,
                        Precio = b.Precio
                    })
                    .ToListAsync(cancellationToken),
                Platillos = await repos.Platillos
                    .AsQueryable()
                    .Where(b => !request.Categoria.HasValue || request.Categoria == OrdenableCategorias.Platillos)
                    .Where(b => string.IsNullOrWhiteSpace(request.PalabraClave)
                        || b.Nombre.Contains(request.PalabraClave))
                    .Select(p => new PlatilloDto
                    {
                        Clave = p.Clave.ToString(),
                        Nombre = p.Nombre,
                        Vegetariano = p.Vegetariano,
                        Precio = p.Precio
                    })
                    .ToListAsync(cancellationToken)
            };
        }
    }
}