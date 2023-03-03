using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
using Markdig;
using Microsoft.AspNetCore.Mvc;

namespace WunderVisionBlog2.Pages.Posts;

public class AddPostModel: PageModel{

    private readonly BlogDBContext _blogContext;
    private readonly IConfiguration _configuration;
    
    [BindProperty]
    public string? Title { get; set; }

    [BindProperty]
    public string? URL { get; set; }

    [BindProperty]
    public string? ThumbnailURL{ get; set; }

    [BindProperty]
    public string? Summary { get; set; }

    [BindProperty]
    public DateTime? Date { get; set; }

    [BindProperty(Name="Content")]
    public string? BlogContent { get; set; }


    public AddPostModel(BlogDBContext context, IConfiguration configuration){
        _blogContext = context;
        _configuration = configuration;
    }

    public IActionResult OnGet(string secret){
        if(secret != _configuration["AddPostSecret"]){
            return Redirect(@"\Posts");
        }
        
        Console.WriteLine("WOO");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string secret){
        Console.WriteLine(secret);
        if(secret != _configuration["AddPostSecret"]){
            return Redirect(@"\Posts");
        }
        Console.WriteLine("POST");
        BlogPost newPost = new BlogPost(){
            Title=Title,
            ThumbnailURL=ThumbnailURL,
            URL=URL,
            Date=Date??default,
            Summary=Summary,
            Content=BlogContent
        };

        _blogContext.Posts.Add(newPost);
        await _blogContext.SaveChangesAsync();

        return Page();
    }
}
