using Dapper;
using Infrustracture.Models;
using Npgsql;

namespace Infrustracture.Services.TaskHistoryService;

public class TaskHistoryService:ITaskHistoryService
{
    public async Task<bool> CreateTaskHistoryAsync(TaskHistory history)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.createTaskHistory, history) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskHistoryAsync(TaskHistory history)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.updateTaskHistory, history) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskHistoryAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.deleteTaskHistory,new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<TaskHistory?> GetTaskHistoryByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<TaskHistory>(SQLCommand.SQLCommand.getTaskHistoryById,new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskHistory>> GetAllTaskHistoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskHistory>(SQLCommand.SQLCommand.getAllTaskHistories);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}