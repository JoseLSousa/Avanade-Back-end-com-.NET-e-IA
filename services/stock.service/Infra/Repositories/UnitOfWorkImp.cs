using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories
{
    public class UnitOfWorkImp(AppDbContext context) : UnitOfWork
    {
        public async Task Commit(CancellationToken concellationToken)
        {
            await context.SaveChangesAsync(concellationToken);
        }
    }
}
