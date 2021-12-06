using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IRepository<TEntity> : IAppendRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, Action<TEntity> updateAction, CancellationToken cancellationToken = default);
        IQueryable<TEntity> AsQueryable();
    }
}