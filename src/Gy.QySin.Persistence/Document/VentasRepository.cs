using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.Persistence.Document
{
    public class VentasRepository : DocumentRepository<Venta>
    {
        public VentasRepository(ICouchClientFactory clientFactory) : base(clientFactory)
        {}

        public override async Task AddAsync(Venta entity, CancellationToken cancellationToken = default)
        {
            using var ventasClient = clientFactory.ForDatabase("ventas");
            var res = await ventasClient.Documents.PostAsync(
                JsonSerializer.Serialize(entity),
                cancellationToken);
            if (!res.IsSuccess)
            {
                throw new System.SystemException("No se pudo acceder a la base de datos.");
            }
            entity.Id = res.Id;

            using var detalleClient = clientFactory.ForDatabase("detalleventas");
            var responseTasks = entity.ExtraerOrdenes().Select(
                o => detalleClient.Documents.PostAsync(
                    JsonSerializer.Serialize(o),
                    cancellationToken
                )
            );
            await Task.WhenAll(responseTasks);
        }
    }
}