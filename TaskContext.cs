using Microsoft.EntityFrameworkCore;
using projectef.Models;


namespace projectef;

public class TaskContext: DbContext
{
    public DbSet<Category> Categories {get; set; }
    public DbSet<ToDo> Task {get; set;}
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(cat => {
            cat.ToTable("Category");
            cat.HasKey(p => p.CategoryId);
            cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
            cat.Property(p => p.Description);
        });
    }
} 