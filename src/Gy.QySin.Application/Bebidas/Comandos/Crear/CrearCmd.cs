using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Bebidas.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Nombre { get; set; }
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
    }
    public class CrearCmdMnjr : IRequestHandler<CrearCmd>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<Unit> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var entity = new Bebida(
                request.Nombre,
                request.Contenido,
                request.Rellenable
            );

            await repos.Bebidas.AddAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}