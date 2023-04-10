using ToDo.Logic.Models.Database;

namespace ToDo.Logic.Models.Dto;

public class UserDto : UserCreate
{
    public int Id { get; set; }
    
    public static UserDto FromDatabase(User user)
    {
        return new()
        {
            Id = user.Id,
            Email = user.Email
        };
    }
}