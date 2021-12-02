using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetAsync(object pk, CancellationToken cancellationToken = default);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, Action<TEntity> updateAction, CancellationToken cancellationToken = default);
        IQueryable<TEntity> AsQueryable();
    }
}