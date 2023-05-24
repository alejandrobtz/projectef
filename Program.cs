using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDb"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTodo"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async([FromServices] TaskContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/todos", async([FromServices] TaskContext dbContext) => {
    return Results.Ok(dbContext.Task.Include(p => p.Category).Where(p => p.Priority == projectef.Models.PriorityEnum.Low));
});

app.MapPost("/api/todos", async([FromServices] TaskContext dbContext, [FromBody] ToDo Todo) => {    

    Todo.TaskId = Guid.NewGuid();
    Todo.CreatedTime = DateTime.Now;
    //await dbContext.AddAsync(Todo);
    await dbContext.Task.AddAsync(Todo);  //this option can also be used.

    await dbContext.SaveChangesAsync();



    return Results.Ok();
});

app.Run();
