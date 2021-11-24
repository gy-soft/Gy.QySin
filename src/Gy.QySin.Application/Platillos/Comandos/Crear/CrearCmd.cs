using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Platillos.Comandos.Crear
{
    public class CrearCmd : IRequest<string>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripción { get; set; }
        public bool Vegetariano { get; set; }
    }
    public class CrearCmdMnjr : IRequestHandler<CrearCmd, string>
    {
        private readonly IApplicationRepositories repos;

        public CrearCmdMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<string> Handle(CrearCmd request, CancellationToken cancellationToken)
        {
            var entity = new Platillo(
                request.Nombre,
                request.Precio,
                request.Descripción,
                request.Vegetariano
            );

            var id = await repos.Platillos.AddAsync(entity, cancellationToken);

            return id.ToString();
        }
    }
}