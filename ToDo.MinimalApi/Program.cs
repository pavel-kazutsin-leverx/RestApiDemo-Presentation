using ToDo.Logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterLogicServices();

var app = builder.Build();

app.MapGet("/", () => "\tI'm alive!\nREST Architecture presentation; Homjel', 2023\n");

app.Run();