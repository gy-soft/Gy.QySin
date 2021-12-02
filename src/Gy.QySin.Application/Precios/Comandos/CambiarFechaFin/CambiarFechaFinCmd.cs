using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Precios.Comandos.CambiarFechaFin
{
    public class CambiarFechaFinCmd : IRequest
    {
        public string Clave { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    }
    public class CambiarFechaFinCmdMnjr : IRequestHandler<CambiarFechaFinCmd>
    {
        private readonly IApplicationRepositories repos;

        public CambiarFechaFinCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<Unit> Handle(CambiarFechaFinCmd request, CancellationToken cancellationToken)
        {
            var guid = System.Guid.Parse(request.Clave);
            var entity = await repos.PrecioOrdenables
                .GetAsync(new object[] { guid, request.FechaInicio }, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(PrecioOrdenable), request.Clave);
            }

            System.Action<PrecioOrdenable> updateAction = (precio) =>
            {
                precio.FechaFin = request.FechaFin;
            };
            await repos.PrecioOrdenables.UpdateAsync(entity, updateAction, cancellationToken);

            return Unit.Value;
        }
    }
}