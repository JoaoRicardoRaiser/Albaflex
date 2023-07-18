namespace Albaflex.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}