using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;
using System;

namespace Gy.QySin.Application.Ordenables.Comandos.ExtenderOrdenable
{
    public class ExtenderOrdenableCmd : IRequest
    {
        public string Clave { get; set; }
        public decimal Precio { get; set; }
    }
    public class ExtenderOrdenableCmdMnjr : IRequestHandler<ExtenderOrdenableCmd>
    {
        private readonly IApplicationRepositories repos;

        public ExtenderOrdenableCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(ExtenderOrdenableCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Ordenables
                .GetAsync(pk, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ordenable), request.Clave);
            }

            Action<Ordenable> updateAction = (ordenable) =>
            {
                ordenable.Precio = request.Precio;
            };
            await repos.Ordenables.UpdateAsync(entity, updateAction);

            return Unit.Value;
        }
    }
}