using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Platillos.ExtenderPlatillo
{
    public class ExtenderPlatilloCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripción { get; set; }
        public bool? Vegetariano { get; set; }
    }
    public class ExtenderPlatilloCmdMnjr : IRequestHandler<ExtenderPlatilloCmd>
    {
        private readonly IApplicationDbContext context;

        public ExtenderPlatilloCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ExtenderPlatilloCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Platillos
                .FindAsync(pk);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Platillo), request.Clave);
            }

            entity.Nombre = request.Nombre ?? entity.Nombre;
            entity.Imagen = request.Imagen ?? entity.Imagen;
            entity.Descripción = request.Descripción ?? entity.Descripción;
            entity.Vegetariano = request.Vegetariano ?? entity.Vegetariano;

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}