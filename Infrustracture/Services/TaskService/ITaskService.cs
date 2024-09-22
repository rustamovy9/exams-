using Infrustracture.Models;

namespace Infrustracture.Services.TaskService;

public interface ITaskService
{
    Task<bool> CreateTaskAsync(Tasks task);
    Task<bool> UpdateTaskAsync(Tasks task);
    Task<bool> DeleteTaskAsync(Guid taskId);
    Task<Tasks> GetTaskByIdAsync(Guid taskId);
    Task<IEnumerable<Tasks>> GetTasksAsync();
}