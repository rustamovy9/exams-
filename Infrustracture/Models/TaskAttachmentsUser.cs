namespace Infrustracture.Models;

public class TaskAttachmentsUser
{
    public string FilePath { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}