namespace Infrustracture.Models;

public class TasksUsersCategories
{
    public Guid TaskId { get; set; }
    public string TaskTitle { get; set; } = null!;
    public string TaskDescription { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string Priority { get; set; } = null!;
}