using Microsoft.EntityFrameworkCore;
using projectef.Models;


namespace projectef;

public class TaskContext: DbContext
{
    public DbSet<Category> Categories {get; set; }
    public DbSet<ToDo> Task {get; set;}
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
} 