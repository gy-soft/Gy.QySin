using System;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Precios.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Clave { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
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
            Guid clave = Guid.Parse(request.Clave);
            var entity = new PrecioOrdenable(clave, request.FechaInicio)
            {
                Precio = request.Precio,
                FechaFin = request.FechaFin
            };
            await repos.PrecioOrdenables.AddAsync(entity);
            return Unit.Value;
        }
    }
}