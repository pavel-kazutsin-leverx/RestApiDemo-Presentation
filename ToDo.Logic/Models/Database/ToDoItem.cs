using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Logic.Models.Dto;

namespace ToDo.Logic.Models.Database;

public class ToDoItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(200)]
    public string Title { get; set; } = default!;

    [MaxLength(2000)] 
    public string Description { get; set; } = default!;
    
    public bool IsCompleted { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}