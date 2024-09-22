namespace Infrustracture.Models;

public class CommentTaskbyUser
{
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; } = null!;
    
}