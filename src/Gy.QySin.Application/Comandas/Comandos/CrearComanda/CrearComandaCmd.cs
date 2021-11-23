using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Comandas.Comandos.CrearComanda
{
    public class CrearComandaCmd : IRequest<int>
    {
        public string Mesero { get; set; }
        public int Mesa { get; set; }
    }
    public class CrearComandaCmdMnjr : IRequestHandler<CrearComandaCmd, int>
    {
        private readonly IApplicationRepositories repos;

        public CrearComandaCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<int> Handle(CrearComandaCmd request, CancellationToken cancellationToken)
        {
            var entity = new Comanda(request.Mesero, request.Mesa);
            entity.FechaHoraAlta = System.DateTime.Now;

            await repos.Comandas.AddAsync(entity, cancellationToken);

            return entity.NúmeroComanda;
        }
    }
}