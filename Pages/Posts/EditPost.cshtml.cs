using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace WunderVisionBlog2.Pages.Posts;

public class EditPostModel : PageModel
{

    private readonly BlogDBContext _blogContext;
    private readonly IConfiguration _configuration;

    [BindProperty]
    public string? Title { get; set; }

    [BindProperty]
    public string? URL { get; set; }

    [BindProperty]
    public string? ThumbnailURL { get; set; }

    [BindProperty]
    public string? Summary { get; set; }

    [BindProperty]
    public DateTime? Date { get; set; }

    [BindProperty(Name = "Content")]
    public string? BlogContent { get; set; }

    public BlogPost? CurrentPost { get; set; }

    public EditPostModel(BlogDBContext context, IConfiguration configuration)
    {
        _blogContext = context;
        _configuration = configuration;
    }

    private async Task<BlogPost?> GetBlogPostAsync(int id)
    {
        try{
            return await _blogContext.Posts.Where(post => post.Id == id).FirstAsync();
        }catch(Exception){
            return null;
        }
        
    }

    public async Task<IActionResult> OnGetAsync(int id, string secret)
    {
        if (secret != _configuration["AddPostSecret"])
        {
            return Redirect(@"\Posts");
        }

        CurrentPost = await GetBlogPostAsync(id);
        if (CurrentPost == null) { return Redirect(@"\AddPost\" + secret); }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, string secret)
    {
        CurrentPost = await GetBlogPostAsync(id);
        if (CurrentPost == null) { return Redirect(@"\AddPost\" + secret); }
        Console.WriteLine(secret);
        if (secret != _configuration["AddPostSecret"])
        {
            return Redirect(@"\Posts");
        }

        if (Title != null) { CurrentPost.Title = Title; };
        if (URL != null) { CurrentPost.URL = URL; };
        if (ThumbnailURL != null) { CurrentPost.ThumbnailURL = ThumbnailURL; }
        if (Summary != null) { CurrentPost.Summary = Summary; };
        if (Date != null) { CurrentPost.Date = (DateTime)Date; }
        if (BlogContent != null) { CurrentPost.Content = BlogContent; }

        await _blogContext.SaveChangesAsync();

        return Page();
    }
}
