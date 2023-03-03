using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
namespace WunderVisionBlog2.Pages.Posts;

public class PostModel: PageModel{

    public string? Title { get; set; }
    private readonly BlogDBContext _blogContext;
    
    public BlogPost? Post { get; set; }

    public PostModel(BlogDBContext context){
        _blogContext = context;
    }

    public async Task OnGetAsync(string title){
        Title = title;
        Console.WriteLine(Title);
        Post = await _blogContext.Posts.AsNoTracking().Where(post=>post.Title==Title).FirstAsync();
    }
}
