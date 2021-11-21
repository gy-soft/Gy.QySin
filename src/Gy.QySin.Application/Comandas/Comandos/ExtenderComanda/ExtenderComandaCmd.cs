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
        private readonly IApplicationDbContext context;

        public ExtenderComandaCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ExtenderComandaCmd request, CancellationToken cancellationToken)
        {
            var entity = await context.Comandas
                .FindAsync(request.NumeroComanda);
            
            entity.AgregarOrdenes(request.Ordenes);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}