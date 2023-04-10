using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Logic.Database;
using ToDo.Logic.Services;

namespace ToDo.Logic;

public static class ProjectRegistration
{
    public static IServiceCollection RegisterLogicServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDataContext>(builder => builder.UseInMemoryDatabase("ToDoItemsDatabase"));
        services.AddScoped<ToToItemsService>();
        services.AddScoped<UsersService>();

        return services;
    }
}