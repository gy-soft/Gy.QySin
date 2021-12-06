using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IAppendRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetAsync(object[] pk, CancellationToken cancellationToken = default);
    }
}