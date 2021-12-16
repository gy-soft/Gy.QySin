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
    public interface IReportRepository<TDaily>
    {
        Task<IEnumerable<TDaily>> GetDailyReportAsync(
            IFechaParams query,
            CancellationToken cancellationToken = default);
    }
}