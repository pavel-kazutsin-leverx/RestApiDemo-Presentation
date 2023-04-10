using Microsoft.EntityFrameworkCore;
using ToDo.Logic.Models.Database;

namespace ToDo.Logic.Database;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoItem>().HasKey(item => item.Id);
        modelBuilder.Entity<ToDoItem>().HasOne<User>(e => e.User).WithMany(e => e.ToDoItems);
        modelBuilder.Entity<User>().HasKey(item => item.Id);
    }
    
}