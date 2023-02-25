using Microsoft.EntityFrameworkCore;

namespace WunderVisionBlog2.Models.Blog;
public class BlogDBContext: DbContext{

    public DbSet<BlogPost> Posts{ get; set; }
    public DbSet<Tag> Tags{ get; set; }

    public BlogDBContext(DbContextOptions<BlogDBContext> options)
    : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder
            .Entity<BlogPost>()
            .HasMany(p => p.Tags)
            .WithMany(p => p.Posts)
            .UsingEntity(j => j.ToTable("PostTags"));
    }
}