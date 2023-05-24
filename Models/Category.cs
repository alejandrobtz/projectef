using System.ComponentModel.DataAnnotations;

namespace projectef.Models;


public class Category
{
    //[Key]
    public Guid CategoryId {get; set;}

    //[Required]
    //[MaxLength(150)]
    public string Name {get; set;}
    public string Description {get; set;}
    public int EffortGrade {get; set;}
    public virtual ICollection<ToDo> Tasks {get; set;}
}



