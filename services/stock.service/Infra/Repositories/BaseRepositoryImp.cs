using Domain.Entities.Common;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BaseRepositoryImp<T>(AppDbContext context) : BaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            context.Add(entity);
        }
        public void Update(T entity)
        {
            entity.Update();
            context.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity != null) context.Set<T>().Remove(entity);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }

    }
}
