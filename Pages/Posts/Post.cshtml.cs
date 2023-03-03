using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
using Markdig;
namespace WunderVisionBlog2.Pages.Posts;

public class PostModel: PageModel{

    public string? Url { get; set; }
    private readonly BlogDBContext _blogContext;
    
    public BlogPost? Post { get; set; }

    public string? HTMLContent { get; set; }

    public PostModel(BlogDBContext context){
        _blogContext = context;
    }

    public async Task OnGetAsync(string url){
        Url = url;
        Console.WriteLine(Url);
        Post = await _blogContext.Posts.AsNoTracking().Where(post=>post.URL==url).FirstAsync();
        if(Post == null) { return; }

        HTMLContent = Markdown.ToHtml(Post.Content);
    }
}
