using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using MyCouch.Requests;

namespace Gy.QySin.Persistence.Document
{
    public class ReportRepository : IReportRepository
    {
        protected readonly ICouchClientFactory clientFactory;

        public ReportRepository(ICouchClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<IEnumerable<DailyReportItem>> GetDailyReportAsync<DailyReportItem>(
            IDateParams dateParams, CancellationToken cancellationToken = default)
        {
            var hoy = System.DateTime.Now;
            QueryViewRequest request = new QueryViewRequest(
                "qysin", "reporteDiario"
            );

            using var ventasClient = clientFactory.ForDatabase("detalleventas");
            var ventasResponse = await ventasClient.Views.QueryAsync<DailyReportItem>(
                RequestFactory.NewDaylyReportRequest("qysin", "reporteDiario", dateParams),
                cancellationToken
            );
            var ventas = ventasResponse.Rows.Select(r => r.Value);

            return ventas;
        }
    }
}