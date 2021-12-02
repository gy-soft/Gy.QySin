using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;
using System;

namespace Gy.QySin.Application.Platillos.Actualizar
{
    public class ActualizarCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripción { get; set; }
        public bool? Vegetariano { get; set; }
    }
    public class ActualizarCmdMnjr : IRequestHandler<ActualizarCmd>
    {
        private readonly IApplicationRepositories repos;

        public ActualizarCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(ActualizarCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Platillos
                .GetAsync(new object[] { pk }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Platillo), request.Clave);
            }

            Action<Platillo> updateAction = (platillo) =>
            {
                platillo.Nombre = request.Nombre ?? platillo.Nombre;
                platillo.Imagen = request.Imagen ?? platillo.Imagen;
                platillo.Descripción = request.Descripción ?? platillo.Descripción;
                platillo.Vegetariano = request.Vegetariano ?? platillo.Vegetariano;
            };

            await repos.Platillos.UpdateAsync(entity, updateAction, cancellationToken);
            return Unit.Value;
        }
    }
}