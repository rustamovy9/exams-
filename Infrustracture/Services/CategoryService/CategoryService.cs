using Dapper;
using Infrustracture.Models;
using Infrustracture.SQLCommand;
using Npgsql;

namespace Infrustracture.Services.CategoryService;

public class CategoryService:ICategoryService
{
    public async Task<bool> CreateCategoryAsync(Categories category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.createCategory,category)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCategoryAsync(Categories category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.updateCategory,category)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SQLCommand.SQLCommand.deleteCategory,new {Id=id})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Categories?> GetCategoryByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Categories>(SQLCommand.SQLCommand.getCategoryById,new {Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommand.SQLCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Categories>(SQLCommand.SQLCommand.getAllCategories);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}