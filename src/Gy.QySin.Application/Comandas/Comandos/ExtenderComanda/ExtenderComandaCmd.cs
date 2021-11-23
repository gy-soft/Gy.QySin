using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Comandas.Comandos.ExtenderComanda
{
    public class ExtenderComandaCmd : IRequest
    {
        public int NumeroComanda { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; }
    }
    public class ExtenderComandaCmdMnjr : IRequestHandler<ExtenderComandaCmd>
    {
        private readonly IApplicationRepositories repos;

        public ExtenderComandaCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(ExtenderComandaCmd request, CancellationToken cancellationToken)
        {
            var entity = await repos.Comandas
                .GetAsync(request.NumeroComanda, cancellationToken);

            Action<Comanda> updateAction = (comanda) =>
            {
                entity.AgregarOrdenes(request.Ordenes);
            };
            await repos.Comandas.UpdateAsync(entity, updateAction);
            return Unit.Value;
        }
    }
}