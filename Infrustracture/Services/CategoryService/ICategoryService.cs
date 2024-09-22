using Infrustracture.Models;

namespace Infrustracture.Services.CategoryService;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync(Categories category);
    Task<bool> UpdateCategoryAsync(Categories category);
    Task<bool> DeleteCategoryAsync(Guid id);
    Task<Categories?> GetCategoryByIdAsync(Guid id);
    Task<IEnumerable<Categories>> GetAllCategoriesAsync();
}