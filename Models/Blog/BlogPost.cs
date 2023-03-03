using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WunderVisionBlog2.Models.Blog;

[Table("Posts")]
public class BlogPost
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string URL { get; set; }
    public string ThumbnailURL { get; set; }
    public string Summary { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    public string Content { get; set; }

    public ICollection<Tag> Tags { get; set; }
}