using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WunderVisionBlog2.Models;

[Table("Posts", Schema="Post")]
public class BlogPost
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Summary { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    public string? Content { get; set; }
    public string? Tags { get; set; }
}