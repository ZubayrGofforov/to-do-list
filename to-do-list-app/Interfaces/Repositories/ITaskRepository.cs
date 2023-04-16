using ToDoListApp.Interfaces.Repositories;

namespace to_do_list_app.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<ToDoListApp.Models.Task>
    {
        public Task<IEnumerable<ToDoListApp.Models.Task>> GetAllByUserIdAsync(long userId, int skip, int take);
    }
}
