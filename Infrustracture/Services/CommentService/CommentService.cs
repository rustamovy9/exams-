using Dapper;
using Infrustracture.Models;
using Npgsql;

namespace Infrustracture.Services.CommentService;

public class CommentService:ICommentService
{
    public async Task<bool> CreateCommentAsync(Comments comments)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.createComment,comments)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCommentAsync(Comments comments)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.updateComment,comments)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCommentAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.deleteComment,new {Id=id})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Comments?> GetCommentByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Comments>(SQLCommand.SQLCommand.getCommentsByTaskId,new {Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Comments>> GetAllCommentsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Comments>(SQLCommand.SQLCommand.getAllComments);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}