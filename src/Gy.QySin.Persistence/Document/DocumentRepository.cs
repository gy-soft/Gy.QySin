using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Persistence.Document
{
    public abstract class DocumentRepository<TEntity> : IDateIndexedRepository<TEntity>
        where TEntity : class
    {
        protected readonly ICouchClientFactory clientFactory;

        public DocumentRepository(ICouchClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public abstract Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        public abstract Task<IEnumerable<TEntity>> QueryByDateAsync(
            IByDateQuery query,
            CancellationToken cancellationToken = default);
    }
}