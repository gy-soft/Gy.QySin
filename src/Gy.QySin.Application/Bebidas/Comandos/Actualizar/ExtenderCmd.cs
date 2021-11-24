using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;
using System;

namespace Gy.QySin.Application.Bebidas.Comandos.Extender
{
    public class ExtenderCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int? Contenido { get; set; }
        public bool? Rellenable { get; set; }
    }
    public class ExtenderCmdMnjr : IRequestHandler<ExtenderCmd>
    {
        private readonly IApplicationRepositories repos;

        public ExtenderCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(ExtenderCmd request, CancellationToken cancellationToken)
        {
            var pk = Guid.Parse(request.Clave);
            var entity = await repos.Bebidas
                .GetAsync(pk, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bebida), request.Clave);
            }

            Action<Bebida> updateAction = (bebida) =>
            {
                bebida.Nombre = request.Nombre ?? bebida.Nombre;
                bebida.Imagen = request.Imagen ?? bebida.Imagen;
                bebida.Contenido = request.Contenido ?? bebida.Contenido;
                bebida.Rellenable = request.Rellenable ?? bebida.Rellenable;
            };

            await repos.Bebidas.UpdateAsync(entity, updateAction, cancellationToken);
            return Unit.Value;
        }
    }
}