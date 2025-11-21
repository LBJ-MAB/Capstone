namespace Capstone.Domain.Dtos;

public class TaskItemDto
{
    public string Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
    public string? Description { get; set; }
    public int? Priority { get; set; }
    public DateOnly? DueDate { get; set; }
}