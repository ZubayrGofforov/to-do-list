using Npgsql;
using to_do_list_app.Constans;
using to_do_list_app.Interfaces.Repositories;

namespace to_do_list_app.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly NpgsqlConnection _connection = new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING);

        public async Task<bool> CreateAsync(ToDoListApp.Models.Task entity)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = "INSERT INTO public.tasks(title, description, begin_time, end_time, status, owner_id) " +
                    "VALUES (@title, @description, @begin_time, @end_time, @status, @owner_id);";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection)
                {
                    Parameters =
                    {
                        new ("title", entity.Title),
                        new ("description", entity.Description),
                        new ("begin_time", entity.BeginTime),
                        new ("end_time", entity.EndTime),
                        new ("status", entity.Status),
                        new ("owner_id", entity.OwnerId)
                    }
                };

                int result = await command.ExecuteNonQueryAsync();

                if (result == 0) return false;
                else return true;
            }
            catch { return false; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = $"DELETE FROM tasks WHERE id = {id}; ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);

                int result = await command.ExecuteNonQueryAsync();

                if (result == 0) return false;
                else return true;

            }
            catch { return false; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<ToDoListApp.Models.Task?> FindByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM tasks WHERE id = {id};";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);
                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new ToDoListApp.Models.Task()
                    {
                        Id = reader.GetInt64(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        BeginTime = reader.GetDateTime(3),
                        EndTime = reader.GetDateTime(4),
                        Status = reader.GetString(5),
                        CreatedAt = reader.GetDateTime(6),
                        OwnerId = reader.GetInt64(7)
                    };
                }
                else return null;
            }
            catch { return null; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<IEnumerable<ToDoListApp.Models.Task>> GetAllAsync(int skip, int take)
        {
            try
            {
                var tasks = new List<ToDoListApp.Models.Task>();
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM tasks ORDER BY created_at OFFSET {skip} LIMIT {take}; ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var task = new ToDoListApp.Models.Task()
                    {
                        Id = reader.GetInt64(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        BeginTime = reader.GetDateTime(3),
                        EndTime = reader.GetDateTime(4),
                        Status = reader.GetString(5),
                        CreatedAt = reader.GetDateTime(6),
                        OwnerId = reader.GetInt64(7)
                    };
                    tasks.Add(task);
                }

                return tasks;
            }
            catch { return new List<ToDoListApp.Models.Task>(); }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<IEnumerable<ToDoListApp.Models.Task>> GetAllByUserIdAsync(long userId, int skip, int take)
        {
            try
            {
                var tasks = new List<ToDoListApp.Models.Task>();
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM tasks WHERE owner_id = {userId} " +
                               $"ORDER BY created_at OFFSET {skip} LIMIT {take}; ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var task = new ToDoListApp.Models.Task()
                    {
                        Id = reader.GetInt64(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        BeginTime = reader.GetDateTime(3),
                        EndTime = reader.GetDateTime(4),
                        Status = reader.GetString(5),
                        CreatedAt = reader.GetDateTime(6),
                        OwnerId = reader.GetInt64(7)
                    };
                    tasks.Add(task);
                }

                return tasks;
            }
            catch { return new List<ToDoListApp.Models.Task>(); }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<bool> UpdateAsync(long id, ToDoListApp.Models.Task entity)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = "UPDATE tasks SET " +
                    "title = @title, description = @description, " +
                    "begin_time = @begin_time, end_time = @end_time, " +
                    "status = @status, created_at = @created_at, owner_id = @owner_id " +
                    $"WHERE id = {id}; ";

                NpgsqlCommand command = new NpgsqlCommand(quary, _connection)
                {
                    Parameters =
                    {
                        new ("title", entity.Title),
                        new ("description", entity.Description),
                        new ("begin_time", entity.BeginTime),
                        new ("end_time", entity.EndTime),
                        new ("status", entity.Status),
                        new ("created_at", entity.CreatedAt),
                        new ("owner_id", entity.OwnerId)
                    }
                };

                int result = await command.ExecuteNonQueryAsync();

                if (result == 0) return false;
                else return true;

            }
            catch { return false; }
            finally { await _connection.CloseAsync(); }
        }
    }
}
