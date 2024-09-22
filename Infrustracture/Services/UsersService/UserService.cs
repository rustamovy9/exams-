using Dapper;
using Infrustracture.Models;
using Npgsql;

namespace Infrustracture.Services.UsersService;

public class UserService:IUserService
{
    public async Task<bool> CreateUserAsync(Users users)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.SQLCommand.createUser,users)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateUserAsync(Users users)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.SQLCommand.updateUser,users)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SQLCommand.SQLCommand.deleteUser,new {Id=userId})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Users?> GetUserByIdAsync(Guid userId)
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Users>(SQLCommand.SQLCommand.getUserById,new {Id=userId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Users>> GetUsersAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Users>(SQLCommand.SQLCommand.getAllUsers);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}