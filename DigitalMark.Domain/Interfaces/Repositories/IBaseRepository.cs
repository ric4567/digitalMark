namespace DigitalMark.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);

        void Update(T entity);

        void RemoveAsync(T entity);
    }
}