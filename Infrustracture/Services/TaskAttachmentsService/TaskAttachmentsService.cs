using Dapper;
using Infrustracture.Models;
using Npgsql;

namespace Infrustracture.Services.TaskAttachmentsService;

public class TaskAttachmentsService:ITaskAttachmentsService
{
    public async Task<bool> CreateTaskAttachmentsAsync(TaskAttachments taskAttachments)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.createTaskAttachment, taskAttachments)>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskAttachmentsAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.deleteTaskAttachment, new {Id=id })>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskAttachmentsAsync(TaskAttachments taskAttachments)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.updateTaskAttachment, taskAttachments)>0;
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<TaskAttachments?> GetTaskAttachmentsByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<TaskAttachments>(SQLCommand.SQLCommand.getTaskAttachmentsById, new {Id=id});
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskAttachments>> GetAllTaskAttachmentsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskAttachments>(SQLCommand.SQLCommand.getAllTaskAttachments);
            }

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}