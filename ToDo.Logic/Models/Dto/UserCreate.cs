using ToDo.Logic.Models.Database;

namespace ToDo.Logic.Models.Dto;

public class UserCreate
{
    public string Email { get; set; } = default!;
    
    public User ToDatabase()
    {
        return new()
        {
            Email = Email
        };
    }
}