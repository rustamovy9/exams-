namespace Infrustracture.Models;

public class Tasks
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Priority { get; set; } = null!;
    public DateTime CreatedAt { get;}= DateTime.Now;
}