namespace Capstone.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
    public string? Description { get; set; }
    public int? Priority { get; set; }
    public DateOnly? DueDate { get; set; }
    public DateOnly? CreatedAt { get; set; }
    public DateOnly? UpdatedAt { get; set; }
}