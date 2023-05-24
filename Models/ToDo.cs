using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

public class ToDo
{
    //[Key]
    public Guid TaskId {get;set;}

    //[ForeignKey("CategoryId")]
    public Guid CategoryId {get; set;}

    // [Required]
    // [MaxLength(200)]
    public string Title {get; set;}

    public string Description {get; set;}

    public PriorityEnum Priority {get; set; }
    public DateTime CreatedTime {get; set;}
    public virtual Category Category {get; set;}

    //[NotMapped]
    public string Summary {get; set;}

}

public enum PriorityEnum
{
    Low,
    Medium,
    High
}