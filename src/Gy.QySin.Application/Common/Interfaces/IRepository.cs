using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(object pk, CancellationToken cancellationToken = default);
        Task<object> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}