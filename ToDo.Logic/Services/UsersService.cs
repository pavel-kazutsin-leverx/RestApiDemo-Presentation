using Microsoft.EntityFrameworkCore;
using ToDo.Logic.Database;
using ToDo.Logic.Models.Dto;

namespace ToDo.Logic.Services;

public class UsersService
{
    private readonly AppDataContext _context;
    
    public UsersService(AppDataContext context)
    {
        _context = context;
    }
    
    public async Task<UserDto> CreateUserAsync(UserCreate userCreate)
    {
        var entry = await _context.Users.AddAsync(userCreate.ToDatabase());
        await _context.SaveChangesAsync();
        
        return UserDto.FromDatabase(entry.Entity);
    }
    
    public async Task<UserDto> GetUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return UserDto.FromDatabase(user);
    }
    
    public async Task<ICollection<UserDto>> GetUsersAsync()
    {
        var users = await _context.Users.Select(e => UserDto.FromDatabase(e)).ToListAsync();
        return users;
    }
    
    public async Task UpdateUserAsync(UserDto userUpdate)
    {
        var user = await _context.Users.FindAsync(userUpdate.Id);
        if (user == null)
            return;
        user.Email = userUpdate.Email;
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}