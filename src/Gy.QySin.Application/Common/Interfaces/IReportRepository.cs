using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IFechaParams
    {
        int Año { get; }
        int Mes { get; }
        int Día { get; }
    }
    public interface IReportRepository
    {
        Task<IEnumerable<TEntity>> GetDailyReportAsync<TEntity>(
            IFechaParams query,
            CancellationToken cancellationToken = default);
    }
}