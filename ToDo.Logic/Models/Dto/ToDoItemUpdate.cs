namespace ToDo.Logic.Models.Dto;

public class ToDoItemUpdate
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool IsCompleted { get; set; }
}