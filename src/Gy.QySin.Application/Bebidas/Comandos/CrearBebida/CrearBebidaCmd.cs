using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Bebidas.Comandos.CrearBebida
{
    public class CrearBebidaCmd : IRequest
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
    }
    public class CrearBebidaCmdMnjr : IRequestHandler<CrearBebidaCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearBebidaCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(CrearBebidaCmd request, CancellationToken cancellationToken)
        {
            var entity = new Bebida(
                request.Nombre,
                request.Precio,
                request.Contenido,
                request.Rellenable
            );

            var id = await repos.Bebidas.AddAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}