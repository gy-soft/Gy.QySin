using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using Gy.QySin.Domain.ValueObjects;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.Application.Ventas.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Anotación { get; set; }
        public List<OrdenDto> Bebidas { get; set; }
        public List<OrdenDto> Platillos { get; set; }
    }
    public class CrearCmdMnjr : IRequestHandler<CrearCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<Unit> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var venta = new Venta(request.Anotación);

            var bebidas = await repos.Bebidas
                .AsQueryable()
                .Where(b => request.Bebidas.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .Join(request.Bebidas,
                    ent => ent.Clave.ToString(),
                    req => req.Clave,
                    (ent, req) => new Orden(req.Clave, ent.Nombre, ent.Precio, req.Cantidad))
                .ToListAsync();
            venta.AgregarOrdenes(bebidas);

            var platillos = await repos.Platillos
                .AsQueryable()
                .Where(p => request.Platillos.Select(x => Guid.Parse(x.Clave))
                    .Contains(p.Clave))
                .Join(request.Platillos,
                    ent => ent.Clave.ToString(),
                    req => req.Clave,
                    (ent, req) => new Orden(req.Clave, ent.Nombre, ent.Precio, req.Cantidad))
                .ToListAsync();
            venta.AgregarOrdenes(platillos);
            // TODO: persistir venta
            throw new System.NotImplementedException();
        }
    }
}