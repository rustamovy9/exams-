using Infrustracture.Models;

namespace Infrustracture.Services.TaskAttachmentsService;

public interface ITaskAttachmentsService
{
    Task<bool> CreateTaskAttachmentsAsync(TaskAttachments taskAttachments);
    Task<bool> DeleteTaskAttachmentsAsync(Guid id);
    Task<bool> UpdateTaskAttachmentsAsync(TaskAttachments taskAttachments);
    Task<TaskAttachments?> GetTaskAttachmentsByIdAsync(Guid id);
    Task<IEnumerable<TaskAttachments>> GetAllTaskAttachmentsAsync();
}