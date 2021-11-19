using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Bebidas.Comandos.ExtenderBebida
{
    public class ExtenderBebidaCmd : IRequest
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int? Contenido { get; set; }
        public bool? Rellenable { get; set; }
    }
    public class ExtenderBebidaCmdMnjr : IRequestHandler<ExtenderBebidaCmd>
    {
        private readonly IApplicationDbContext context;

        public ExtenderBebidaCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(ExtenderBebidaCmd request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await context.Bebidas
                .FindAsync(pk);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bebida), request.Clave);
            }

            entity.Nombre = request.Nombre is null ? entity.Nombre : request.Nombre;
            entity.Imagen = request.Imagen is null ? entity.Imagen : request.Imagen;
            entity.Contenido = request.Contenido ?? entity.Contenido;
            entity.Rellenable = request.Rellenable ?? entity.Rellenable;

            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}