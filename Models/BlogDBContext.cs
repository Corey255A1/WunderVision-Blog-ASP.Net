using Microsoft.EntityFrameworkCore;

namespace WunderVisionBlog2.Models;
public class BlogDBContext: DbContext{

    public DbSet<BlogPost> Posts{ get; set; }

    public BlogDBContext(DbContextOptions<BlogDBContext> options)
    : base(options) {}
}