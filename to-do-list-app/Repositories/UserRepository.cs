using Npgsql;
using to_do_list_app.Constans;
using ToDoListApp.Interfaces.Repositories;
using ToDoListApp.Models;

namespace to_do_list_app.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection = new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING);

        public async Task<bool> CreateAsync(User entity)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = "INSERT INTO users(full_name, email, password_hash, salt) " +
                    "VALUES (@full_name, @email, @password_hash, @salt); ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection)
                {
                    Parameters =
                    {
                        new ("full_name", entity.FullName),
                        new ("email", entity.Email),
                        new ("password_hash", entity.PasswordHash),
                        new ("salt", entity.Salt)
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
                string quary = $"DELETE FROM users WHERE id = {id}; ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);

                int result = await command.ExecuteNonQueryAsync();

                if (result == 0) return false;
                else return true;

            }
            catch { return false; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM users WHERE email = @email;";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection)
                {
                    Parameters =
                    {
                        new ("email", email)
                    }
                };
                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt64(0),
                        FullName = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Salt = reader.GetString(4)
                    };
                }
                else return null;
            }
            catch { return null; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<User?> FindByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM users WHERE id = {id};";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);
                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt64(0),
                        FullName = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Salt = reader.GetString(4)
                    };
                }
                else return null;
            }
            catch { return null; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<IEnumerable<User>> GetAllAsync(int skip, int take)
        {
            try
            {
                var users = new List<User>();
                await _connection.OpenAsync();
                string quary = $"SELECT * FROM users ORDER BY full_name OFFSET {skip} LIMIT {take}; ";
                NpgsqlCommand command = new NpgsqlCommand(quary, _connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt64(0),
                        FullName = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Salt = reader.GetString(4)
                    };
                    users.Add(user);
                }

                return users;
            }
            catch { return new List<User>(); }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<bool> UpdateAsync(long id, User entity)
        {
            try
            {
                await _connection.OpenAsync();
                string quary = "UPDATE users SET " +
                    "full_name = @full_name, email = @email, " +
                    "password_hash = @password_hash, salt = @salt " +
                    $"WHERE id = {id}; ";

                NpgsqlCommand command = new NpgsqlCommand(quary, _connection)
                {
                    Parameters =
                    {
                        new ("full_name", entity.FullName),
                        new ("email", entity.Email),
                        new ("password_hash", entity.PasswordHash),
                        new ("salt", entity.Salt)
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
