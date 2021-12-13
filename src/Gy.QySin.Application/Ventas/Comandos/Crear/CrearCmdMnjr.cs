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
    public class CrearCmdMnjr : IRequestHandler<CrearCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var venta = new Venta(request.Anotación, request.Fecha);
            var fechaVenta = new DateTime(
                request.Fecha[0], request.Fecha[1], request.Fecha[2],
                0, 0, 0, DateTimeKind.Unspecified
            );
            var precioBebidas = await repos.Ordenables
                .AsQueryable()
                .Where(b => request.Bebidas.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .Join(repos.PrecioOrdenables
                    .AsQueryable()
                    .Where(p => p.FechaInicio <= fechaVenta)
                    .Where(p => p.FechaFin == null || p.FechaFin > fechaVenta),
                    b => b.Clave,
                    p => p.Clave,
                (bebida, precio) => new {
                    Categoria = bebida.Categoria,
                    Clave = bebida.Clave.ToString(),
                    Nombre = bebida.Nombre,
                    Precio = precio.Precio
                })
                .ToListAsync();
            var bebidas = precioBebidas.Join(request.Bebidas,
                p => p.Clave,
                b => b.Clave,
                (pb, orden) => new VentaDetalle(pb.Categoria, orden.Clave, pb.Nombre, pb.Precio, orden.Cantidad));
            venta.AgregarOrdenes(bebidas);

            var precioPlatillos = await repos.Ordenables
                .AsQueryable()
                .Where(b => request.Platillos.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .Join(repos.PrecioOrdenables
                    .AsQueryable()
                    .Where(p => p.FechaInicio <= fechaVenta)
                    .Where(p => p.FechaFin == null || p.FechaFin > fechaVenta),
                    pr => pr.Clave,
                    pl => pl.Clave,
                (platillo, precio) => new {
                    Categoria = platillo.Categoria,
                    Clave = platillo.Clave.ToString(),
                    Nombre = platillo.Nombre,
                    Precio = precio.Precio
                })
                .ToListAsync();
            var platillos = precioPlatillos.Join(request.Platillos,
                pr => pr.Clave,
                pl => pl.Clave,
                (pp, orden) => new VentaDetalle(pp.Categoria, pp.Clave, pp.Nombre, pp.Precio, orden.Cantidad));
            venta.AgregarOrdenes(platillos);

            await repos.Ventas.AddAsync(venta);
            return Unit.Value;
        }
    }
}