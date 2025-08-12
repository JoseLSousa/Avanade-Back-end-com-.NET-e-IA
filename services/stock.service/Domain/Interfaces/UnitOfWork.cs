namespace Domain.Interfaces
{
    public interface UnitOfWork
    {
        Task Commit(CancellationToken concellationToken);
    }
}
