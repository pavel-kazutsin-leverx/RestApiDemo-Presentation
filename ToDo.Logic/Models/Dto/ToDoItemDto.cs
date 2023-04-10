using ToDo.Logic.Models.Database;

namespace ToDo.Logic.Models.Dto;

public sealed class ToDoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool IsCompleted { get; set; }
    public int UserId { get; set; }
    
    public static ToDoItemDto FromDatabase(ToDoItem item)
    {
        return new()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            IsCompleted = item.IsCompleted,
            UserId = item.UserId
        };
    }
}