namespace Infrustracture.Models;

public class CategoryWithTaskCount
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public int TaskCount { get; set; }
}