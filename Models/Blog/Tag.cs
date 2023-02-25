using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WunderVisionBlog2.Models.Blog;

[Table("Tags")]
public class Tag
{
    [Key]
    public int Id { get; set; }
    public string Text { get; set; }
    public ICollection<BlogPost> Posts { get; set; }
}