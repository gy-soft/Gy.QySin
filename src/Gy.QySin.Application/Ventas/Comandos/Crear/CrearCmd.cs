using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Ventas.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Nota { get; set; }
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
            var bebidas = await repos.Bebidas
                .AsQueryable()
                .Where(b => request.Bebidas.Select(x => Guid.Parse(x.Clave))
                    .Contains(b.Clave))
                .ToListAsync();
            var platillos = await repos.Platillos
                .AsQueryable()
                .Where(p => request.Platillos.Select(x => Guid.Parse(x.Clave))
                    .Contains(p.Clave))
                .ToListAsync();
            throw new System.NotImplementedException();
        }
    }
}