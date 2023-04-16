namespace ToDoListApp.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        public Task<bool> CreateAsync(T entity);

        public Task<bool> UpdateAsync(long id, T entity);

        public Task<bool> DeleteAsync(long id);

        public Task<IEnumerable<T>> GetAllAsync(int skip, int take);

        public Task<T?> FindByIdAsync(long id);
    }
}
