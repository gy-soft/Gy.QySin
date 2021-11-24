using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Comandas.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Mesero { get; set; }
        public int Mesa { get; set; }
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
            var entity = new Comanda(request.Mesero, request.Mesa);
            entity.FechaHoraAlta = System.DateTime.Now;

            await repos.Comandas.AddAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}