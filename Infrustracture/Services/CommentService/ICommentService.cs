using Infrustracture.Models;

namespace Infrustracture.Services.CommentService;

public interface ICommentService
{
    Task<bool> CreateCommentAsync(Comments comments);
    Task<bool> UpdateCommentAsync(Comments comments);
    Task<bool> DeleteCommentAsync(Guid id);
    Task<Comments?> GetCommentByIdAsync(Guid id);
    Task<IEnumerable<Comments>> GetAllCommentsAsync();
}