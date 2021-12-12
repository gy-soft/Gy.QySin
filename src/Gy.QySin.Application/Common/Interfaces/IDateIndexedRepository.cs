using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IByDateQuery
    {
        int Limit { get; }
        // new object[] { year, month, date }
        int[] Date { get; }
        bool IncludeAggregates { get; }
    }
    public interface IDateIndexedRepository<TEntity>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> QueryByDateAsync(
            IByDateQuery query,
            CancellationToken cancellationToken = default);
    }
}