using ToDo.Logic.Models.Database;

namespace ToDo.Logic.Models.Dto;

public class ToDoItemCreate
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int UserId { get; set; }
    
    public ToDoItem ToDatabase()
    {
        return new()
        {
            Title = Title,
            Description = Description,
            UserId = UserId
        };
    }
}