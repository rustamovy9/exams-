using Infrustracture.Models;

namespace Infrustracture.Services.TaskHistoryService;

public interface ITaskHistoryService
{
    Task<bool> CreateTaskHistoryAsync(TaskHistory history);
    Task<bool> UpdateTaskHistoryAsync(TaskHistory history);
    Task<bool> DeleteTaskHistoryAsync(Guid id);
    Task<TaskHistory?> GetTaskHistoryByIdAsync(Guid id);
    Task<IEnumerable<TaskHistory>> GetAllTaskHistoriesAsync();
}