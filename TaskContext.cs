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
        List<Category> categoriesInit = new List<Category>(); 

        categoriesInit.Add( new Category() { CategoryId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705efc"), Name = "Pending Activities" , EffortGrade = 20 });
        categoriesInit.Add( new Category() { CategoryId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705e02"), Name = "Personal Activities" , EffortGrade = 50 });

        modelBuilder.Entity<Category>(cat => {
            cat.ToTable("Category");
            cat.HasKey(p => p.CategoryId);
            cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
            cat.Property(p => p.Description).IsRequired(false);
            cat.Property(p => p.EffortGrade);
            cat.HasData(categoriesInit);
        });

        List<ToDo> toDoInit = new List<ToDo>();
        toDoInit.Add(new ToDo(){TaskId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705e10"), CategoryId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705efc"), Priority = PriorityEnum.Medium, Title = "Pay Bills", CreatedTime = DateTime.Now});
        toDoInit.Add(new ToDo(){TaskId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705e11"), CategoryId = Guid.Parse("78f16f43-1ed2-4286-a27f-0a8786705e02"), Priority = PriorityEnum.Low, Title = "Watch movie on netflix", CreatedTime = DateTime.Now});


        modelBuilder.Entity<ToDo>(td => {
            td.ToTable("Todo");
            td.HasKey(t => t.TaskId);
            td.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            td.Property(p => p.Title).IsRequired().HasMaxLength(200);
            td.Property(p => p.Description).IsRequired(false);
            td.Property(p => p.Priority);
            td.Property(p => p.CreatedTime);
            td.Ignore(p => p.Summary);
            td.HasData(toDoInit);

        });
    }
} 