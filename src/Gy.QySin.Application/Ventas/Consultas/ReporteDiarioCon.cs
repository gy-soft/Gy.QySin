using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.ValueObjects;
using MediatR;

namespace Gy.QySin.Application.Ventas.Consultas
{
    public class ReporteDiarioCon : IRequest<IEnumerable<ArrObjectKeyDecimalValue>>
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Día { get; set; }
    }
    public class ReporteDiarioConMnjr : IRequestHandler<ReporteDiarioCon, IEnumerable<ArrObjectKeyDecimalValue>>
    {
        private readonly IApplicationRepositories repos;

        public ReporteDiarioConMnjr(IApplicationRepositories repos)
        {
            this.repos = repos;
        }

        public Task<IEnumerable<ArrObjectKeyDecimalValue>> Handle(ReporteDiarioCon request, CancellationToken cancellationToken)
        {
            // return await this.repos.ReportsRepository.GetDailyReportAsync(request)
            throw new System.NotImplementedException();
        }
    }
}