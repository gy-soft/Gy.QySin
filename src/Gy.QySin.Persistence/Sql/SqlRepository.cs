using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Persistence.Sql
{
    public class SqlRepository<TContext, TEntity> : IRepository<TEntity>
        where TContext : ISqlDbContext
        where TEntity : class
    {
        private readonly TContext context;
        private readonly DbSet<TEntity> dbSet;

        public SqlRepository(TContext context, DbSet<TEntity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetAsync(object[] pk, CancellationToken cancellationToken = default)
        {
            return await dbSet.FindAsync(
                pk, cancellationToken
            );
        }

        public async Task UpdateAsync(TEntity entity, Action<TEntity> updateAction, CancellationToken cancellationToken = default)
        {
            updateAction(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return dbSet
                .AsNoTracking()
                .AsQueryable();
        }
    }
}