using ToDo.Logic;
using ToDo.Logic.Models.Dto;
using ToDo.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterLogicServices();

var app = builder.Build();

app.MapGet("/", () => "\tI'm alive!\nREST Architecture presentation; Homjel', 2023\n");

app.MapGet("/users", async (UsersService usersService) => await usersService.GetUsersAsync());
app.MapPost("/users", async (UsersService usersService, UserDto userCreate) => await usersService.CreateUserAsync(userCreate));

app.Run();