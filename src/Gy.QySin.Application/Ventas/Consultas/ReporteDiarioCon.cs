using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.ValueObjects;
using MediatR;

namespace Gy.QySin.Application.Ventas.Consultas
{
    public class ReporteDiarioCon : IRequest<IEnumerable<ReporteVentasItem>>, IFechaParams
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Día { get; set; }
    }
    public class ReporteDiarioConMnjr : IRequestHandler<ReporteDiarioCon, IEnumerable<ReporteVentasItem>>
    {
        private readonly IApplicationRepositories repos;

        public ReporteDiarioConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public async Task<IEnumerable<ReporteVentasItem>> Handle(ReporteDiarioCon request, CancellationToken cancellationToken)
        {
            return await repos.ReportRepository.GetDailyReportAsync(request, cancellationToken);
        }
    }
}