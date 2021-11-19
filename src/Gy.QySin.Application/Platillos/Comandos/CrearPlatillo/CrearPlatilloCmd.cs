using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Platillos.CrearPlatillo
{
    public class CrearPlatilloCmd : IRequest<string>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripción { get; set; }
        public bool Vegetariano { get; set; }
    }
    public class CrearPlatilloCmdMnjr : IRequestHandler<CrearPlatilloCmd, string>
    {
        private readonly IApplicationDbContext context;

        public CrearPlatilloCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(CrearPlatilloCmd request, CancellationToken cancellationToken)
        {
            var entity = new Platillo(
                request.Nombre,
                request.Precio,
                request.Descripción,
                request.Vegetariano
            );

            await context.Platillos.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Clave.ToString();
        }
    }
}