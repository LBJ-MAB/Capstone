namespace Capstone.Domain.Entities;

public class TaskItem
{
    public string Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
    public string? Description { get; set; }
    public int? Priority { get; set; }
    public DateOnly? DueDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}