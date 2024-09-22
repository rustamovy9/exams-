using Dapper;
using Infrustracture.Models;
using Npgsql;
using NpgsqlTypes;

namespace Infrustracture.Services;

public class QueryServices:IQueryServices
{
    public async Task<IEnumerable<UserAndTask>> SelectUserTasksAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<UserAndTask>(SQLCommand.SQLCommand.selectusersTask);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CategoryWithTaskCount>> SelectCategoryTasksCountAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<CategoryWithTaskCount>(SQLCommand.SQLCommand.selectCategoryTaskCount);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Tasks>> SelectTasksByPriorityAsync(string priority)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Tasks>(SQLCommand.SQLCommand.selectTasksByPriority,new {Priority=priority});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TasksUsersCategories>> SelectTasksUsersCategoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TasksUsersCategories>(SQLCommand.SQLCommand.selectTaskUsersCategory);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Tasks>> SelectTasksOrderByDueDateAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Tasks>(SQLCommand.SQLCommand.selectTaskOrderByDuedate);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskHistory>> SelectTaskHistroyByTaskIdAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskHistory>(SQLCommand.SQLCommand.selectTaskHistoryOrderByChangedAt, new {TaskId=taskId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CommentTaskbyUser>> SelectCommentTaskFilteringUserAsync(Guid taskId, Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<CommentTaskbyUser>(SQLCommand.SQLCommand.selectCommentTaskFiltringUser, new {TaskId=taskId, UserId=userId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TaskAttachmentsUser>> SelectTaskAttachmentsUserAsync(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskAttachmentsUser>(SQLCommand.SQLCommand.selectAllTaskAttachmentsTaskUser, new {TaskId=taskId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Tasks>> selectTaskFiltringDueDateAsync(string date)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Tasks>(SQLCommand.SQLCommand.selectTaskFiltringDueDate, new {DueDate=date});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Tasks>> SelectAllTaskFiltringIsStatuseAndPriorityAsync(bool iscomplated, string priority)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Tasks>(SQLCommand.SQLCommand.selectAllTaskFiltringIsStatuseAndPriority, new {IsCompleted=iscomplated, Priority=priority});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}