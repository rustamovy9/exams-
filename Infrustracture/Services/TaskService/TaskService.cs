using Dapper;
using Infrustracture.Models;
using Npgsql;

namespace Infrustracture.Services.TaskService;

public class TaskService:ITaskService
{
    public async Task<bool> CreateTaskAsync(Tasks task)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.createTask, task)>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskAsync(Tasks task)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.updateTask, task)>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.deleteTask,new {Id=taskId})>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Tasks> GetTaskByIdAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Tasks>(SQLCommand.SQLCommand.getTaskById,new {Id=taskId});
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Tasks>> GetTasksAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Tasks>(SQLCommand.SQLCommand.getAllTasks);
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}