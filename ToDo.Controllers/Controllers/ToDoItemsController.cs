using Microsoft.AspNetCore.Mvc;
using ToDo.Logic.Models.Dto;
using ToDo.Logic.Services;

namespace ToDo.MinimalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly ToDoItemsService _toDoItemsService;
    
    public ToDoItemsController(ToDoItemsService toDoItemsService)
    {
        _toDoItemsService = toDoItemsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _toDoItemsService.GetToDoItemsAsync();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetItemByIdAsync(int id)
    {
        var result = await _toDoItemsService.GetToDoItemAsync(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateItemAsync(ToDoItemCreate toDoItemCreate)
    {
        var result = await _toDoItemsService.CreateToDoItemAsync(toDoItemCreate);
        return Created($"/ToDoItems/{result.Id}", result);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateItemAsync(int id, ToDoItemUpdate toDoItemUpdate)
    {
        toDoItemUpdate.Id = id;
        await _toDoItemsService.UpdateToDoItemAsync(id, toDoItemUpdate);
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItemAsync(int id)
    {
        await _toDoItemsService.DeleteToDoItemAsync(id);
        return Ok();
    }
}