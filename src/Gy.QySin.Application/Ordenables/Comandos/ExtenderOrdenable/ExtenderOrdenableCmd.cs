using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Ordenables.Comandos.ExtenderOrdenable
{
    public class ExtenderOrdenableCmd : IRequest
    {
        public string Clave { get; set; }
        public decimal Precio { get; set; }
    }
    public class ExtenderOrdenableCmdMnjr : IRequestHandler<ExtenderOrdenableCmd>
    {
        private readonly IApplicationDbContext context;

        public ExtenderOrdenableCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ExtenderOrdenableCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Ordenables
                .FindAsync(pk);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ordenable), request.Clave);
            }
            
            entity.Precio = request.Precio;
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}