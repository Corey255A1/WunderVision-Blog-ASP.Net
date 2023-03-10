using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WunderVisionBlog2.Models.Blog;
namespace WunderVisionBlog2.Pages.Posts;

public class IndexModel: PageModel{

    private readonly BlogDBContext _blogContext;
    public IList<BlogPost>? Posts { get; set; }

    public IndexModel(BlogDBContext context){
        _blogContext = context;
    }

    public async Task OnGetAsync(){
        Posts = await _blogContext.Posts.AsNoTracking().Include(p=>p.Tags).ToListAsync();
    }
}
