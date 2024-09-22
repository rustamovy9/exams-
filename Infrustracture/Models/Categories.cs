namespace Infrustracture.Models;

public class Categories
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get;} = DateTime.Now;
}