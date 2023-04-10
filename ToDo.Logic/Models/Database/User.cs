namespace ToDo.Logic.Models.Database;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; } = default!;

    public ICollection<ToDoItem>? ToDoItems { get; set; }
}