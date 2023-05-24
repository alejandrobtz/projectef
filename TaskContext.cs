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
            cat.Property(p => p.EffortGrade);
        });

        modelBuilder.Entity<ToDo>(td => {
            td.ToTable("Todo");
            td.HasKey(t => t.TaskId);
            td.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            td.Property(p => p.Title).IsRequired().HasMaxLength(200);
            td.Property(p => p.Description);
            td.Property(p => p.Priority);
            td.Property(p => p.CreatedTime);
            td.Ignore(p => p.Summary);

        });
    }
} 