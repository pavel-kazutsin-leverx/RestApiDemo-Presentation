using Microsoft.EntityFrameworkCore;
using ToDo.Logic.Database;
using ToDo.Logic.Models.Dto;

namespace ToDo.Logic.Services;

public class ToDoItemsService
{
    private readonly AppDataContext _dataContext;
    
    public ToDoItemsService(AppDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<ToDoItemDto> CreateToDoItemAsync(ToDoItemCreate toDoItemCreate)
    {
        var entry = await _dataContext.ToDoItems.AddAsync(toDoItemCreate.ToDatabase());
        await _dataContext.SaveChangesAsync();

        return ToDoItemDto.FromDatabase(entry.Entity);
    }
    
    public async Task<ToDoItemDto> GetToDoItemAsync(int id)
    {
        var item = await _dataContext.ToDoItems.FindAsync(id);
        return ToDoItemDto.FromDatabase(item);
    }
    
    public async Task<ICollection<ToDoItemDto>> GetToDoItemsAsync()
    {
        var items = await _dataContext.ToDoItems.Select(e => ToDoItemDto.FromDatabase(e)).ToListAsync();
        return items;
    }
    
    public async Task UpdateToDoItemAsync(int id, ToDoItemUpdate toDoItemUpdate)
    {
        var item = await _dataContext.ToDoItems.FindAsync(id);
        if (item == null)
            return;
        item.Title = toDoItemUpdate.Title;
        item.Description = toDoItemUpdate.Description;
        item.IsCompleted = toDoItemUpdate.IsCompleted;
        await _dataContext.SaveChangesAsync();
    }
    
    public async Task DeleteToDoItemAsync(int id)
    {
        var item = await _dataContext.ToDoItems.FindAsync(id);
        if (item == null)
            return;
        _dataContext.ToDoItems.Remove(item);
        await _dataContext.SaveChangesAsync();
    }
}