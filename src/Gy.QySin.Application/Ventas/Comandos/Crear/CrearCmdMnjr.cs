using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Ventas.Comandos.Crear
{
    public class CrearCmdMnjr2 : IRequestHandler<CrearCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr2(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var venta = new Venta(request.Anotación);
            var precioBebidas = await repos.Ordenables
                .AsQueryable()
                .Where(b => request.Bebidas.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .Join(repos.PrecioOrdenables
                    .AsQueryable()
                    .Where(p => p.FechaInicio >= request.FechaHora)
                    .Where(p => p.FechaFin == null || p.FechaFin < request.FechaHora),
                    b => b.Clave,
                    p => p.Clave,
                (bebida, precio) => new {
                    Clave = bebida.Clave.ToString(),
                    Nombre = bebida.Nombre,
                    Precio = precio.Precio
                })
                .ToListAsync();
            var bebidas = precioBebidas.Join(request.Bebidas,
                p => p.Clave,
                b => b.Clave,
                (pb, orden) => new Orden(orden.Clave, pb.Nombre, pb.Precio, orden.Cantidad));
            venta.AgregarOrdenes(bebidas);

            var precioPlatillos = await repos.Ordenables
                .AsQueryable()
                .Where(b => request.Platillos.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .Join(repos.PrecioOrdenables
                    .AsQueryable()
                    .Where(p => p.FechaInicio >= request.FechaHora)
                    .Where(p => p.FechaFin == null || p.FechaFin < request.FechaHora),
                    pr => pr.Clave,
                    pl => pl.Clave,
                (platillo, precio) => new {
                    Clave = platillo.Clave.ToString(),
                    Nombre = platillo.Nombre,
                    Precio = precio.Precio
                })
                .ToListAsync();
            var platillos = precioPlatillos.Join(request.Platillos,
                pr => pr.Clave,
                pl => pl.Clave,
                (pp, orden) => new Orden(pp.Clave, pp.Nombre, pp.Precio, orden.Cantidad));
            venta.AgregarOrdenes(platillos);

            await repos.Ventas.AddAsync(venta);
            return Unit.Value;
        }
    }
}