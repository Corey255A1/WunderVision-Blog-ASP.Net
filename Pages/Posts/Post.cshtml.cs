using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
using Markdig;
namespace WunderVisionBlog2.Pages.Posts;

public class PostModel: PageModel{

    
    private readonly BlogDBContext _blogContext;
    private readonly IConfiguration _configuration;
    
    public string CDNURL { get; set; }
    public string? PageURL { get; set; }
    public BlogPost? Post { get; set; }
    public string? HTMLContent { get; set; }

    public PostModel(BlogDBContext context, IConfiguration configuration){
        _blogContext = context;
        _configuration = configuration;
        CDNURL = _configuration["CDNURL"]??"";

    }

    public async Task OnGetAsync(string url){
        PageURL = url;
        Console.WriteLine(PageURL);
        Post = await _blogContext.Posts.AsNoTracking().Where(post=>post.URL==url).FirstAsync();
        if(Post == null) { return; }

        HTMLContent = Markdown.ToHtml(Post.Content).Replace("@CDNURL", CDNURL);
    }
}
