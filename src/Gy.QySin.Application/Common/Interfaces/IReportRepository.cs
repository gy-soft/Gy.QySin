using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IDateParams
    {
        int Year { get; }
        int Month { get; }
        int Day { get; }
    }
    public interface IReportRepository
    {
        Task<IEnumerable<TEntity>> GetDailyReportAsync<TEntity>(
            IDateParams query,
            CancellationToken cancellationToken = default);
    }
}