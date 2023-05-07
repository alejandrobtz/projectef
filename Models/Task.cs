namespace projectef.Models;

public class ToDo
{
    public Guid TaskId {get;set;}
    public Guid CategoryId {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}

    public PriorityEnum Priority {get; set; }
    DateTime CreatedTime {get; set;}
    public virtual Category Category {get; set;}

}

public enum PriorityEnum
{
    Low,
    Medium,
    High
}