using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Domain.ValueObjects;
using Gy.QySin.Application.Common.Interfaces;
using MyCouch.Requests;

namespace Gy.QySin.Persistence.Document
{
    public class ReportRepository : IReportRepository<ReporteVentasItem>
    {
        protected readonly ICouchClientFactory clientFactory;

        public ReportRepository(ICouchClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
    
        public async Task<IEnumerable<ReporteVentasItem>> GetDailyReportAsync(
            IFechaParams query,
            CancellationToken cancellationToken = default
        )
        {
            var hoy = System.DateTime.Now;
            QueryViewRequest request = RequestFactory.NewDaylyReportRequest("qysin", "reporteDiario", query);

            using var ventasClient = clientFactory.ForDatabase("detalleventas");
            
            var ventasResponse = await ventasClient.Views.QueryAsync<decimal>(
                RequestFactory.NewDaylyReportRequest("qysin", "reporteDiario", query),
                cancellationToken
            );
            var ventas = ventasResponse.Rows
            .Select(r => new ArrObjectKeyDecimalValue
            {
                Key = (object[])r.Key,
                Value = r.Value
            })
            .Select(kv => new ReporteVentasValorPuntual(kv, ReporteVentasValorPuntual.Periodos.Diario));
            return ventas.AReporteVentasItems();
        }
    }
}