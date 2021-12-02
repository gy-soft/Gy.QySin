using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Application.Common.Exceptions;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Usuarios.Consultas.Detalle
{
    public class DetalleCon : IRequest<DetalleDto>
    {
        public string Clave { get; set; }
    }
    public class DetalleConMnjr : IRequestHandler<DetalleCon, DetalleDto>
    {
        private readonly IApplicationRepositories repos;

        public DetalleConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }
        public async Task<DetalleDto> Handle(DetalleCon request, CancellationToken cancellationToken)
        {
            var pk = System.Guid.Parse(request.Clave);
            var entity = await repos.Usuarios
                .GetAsync(new object[] { pk }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Clave);
            }

            return new DetalleDto
            {
                Clave = entity.Clave.ToString(),
                Nombre = entity.Nombre,
                NombreCorto = entity.NombreCorto,
                Activo = entity.Activo,
                Roles = entity.Roles
            };
        }
    }
}