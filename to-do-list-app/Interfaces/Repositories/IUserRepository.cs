using ToDoListApp.Models;

namespace ToDoListApp.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> FindByEmailAsync(string email);
    }
}
