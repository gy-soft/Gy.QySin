using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MyCouch.Requests;
using MyCouch.Responses;

namespace Gy.QySin.Persistence.Document
{
    public class VentasRepository : DocumentRepository<Venta>
    {
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public VentasRepository(ICouchClientFactory clientFactory) : base(clientFactory)
        {}

        public override async Task AddAsync(Venta entity, CancellationToken cancellationToken = default)
        {
            entity.Id = IdFactory.NewId(entity);
            using var ventasClient = clientFactory.ForDatabase("ventas");
            var res = await ventasClient.Documents.PostAsync(
                JsonSerializer.Serialize(entity, serializerOptions),
                cancellationToken);
            if (!res.IsSuccess)
            {
                throw new System.SystemException("No se pudo acceder a la base de datos.");
            }

            var responseTasks = new List<Task>();
            List<VentaDetalle> ventaDetalles = entity.ExtraerDetalles();
            VentaDetalle vd;
            using var detalleClient = clientFactory.ForDatabase("detalleventas");
            for (int i = 0; i < ventaDetalles.Count; i++)
            {
                vd = ventaDetalles[i];
                vd.Id = $"{entity.Id}:{i}";
                responseTasks.Add(
                    detalleClient.Documents.PostAsync(
                        JsonSerializer.Serialize(vd, serializerOptions),
                        cancellationToken
                    )
                );
            }
            
            await Task.WhenAll(responseTasks);
        }
    }
}