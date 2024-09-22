using Infrustracture.Models;

namespace Infrustracture.Services;

public interface IQueryServices
{
    Task<IEnumerable<UserAndTask>> SelectUserTasksAsync();
    Task<IEnumerable<CategoryWithTaskCount>> SelectCategoryTasksCountAsync();
    Task<IEnumerable<Tasks>> SelectTasksByPriorityAsync(string priority);  
    Task<IEnumerable<TasksUsersCategories>> SelectTasksUsersCategoriesAsync();
    Task<IEnumerable<Tasks>> SelectTasksOrderByDueDateAsync();
    Task<IEnumerable<TaskHistory>> SelectTaskHistroyByTaskIdAsync(Guid taskId);
    Task<IEnumerable<CommentTaskbyUser>> SelectCommentTaskFilteringUserAsync(Guid taskId, Guid userId);
    Task<IEnumerable<TaskAttachmentsUser>> SelectTaskAttachmentsUserAsync(Guid taskId);
    Task<IEnumerable<Tasks>> selectTaskFiltringDueDateAsync(string date);
    Task<IEnumerable<Tasks>> SelectAllTaskFiltringIsStatuseAndPriorityAsync(bool iscomplated,string priority);
}
