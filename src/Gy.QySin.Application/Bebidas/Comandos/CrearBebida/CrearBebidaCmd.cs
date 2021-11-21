using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Bebidas.Comandos.CrearBebida
{
    public class CrearBebidaCmd : IRequest<string>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
    }
    public class CrearBebidaCmdMnjr : IRequestHandler<CrearBebidaCmd, string>
    {
        private readonly IApplicationDbContext context;

        public CrearBebidaCmdMnjr(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(CrearBebidaCmd request, CancellationToken cancellationToken)
        {
            // TODO: Agregar validador de nombre único
            var entity = new Bebida(
                request.Nombre,
                request.Precio,
                request.Contenido,
                request.Rellenable
            );

            await context.Bebidas.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Clave.ToString();
        }
    }
}