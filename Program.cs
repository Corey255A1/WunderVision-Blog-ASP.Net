using WunderVisionBlog2.Models.Blog;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MariaDbServerVersion(new Version(15,1));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BlogDBContext>(options=>{
               options.UseMySql(builder.Configuration.GetConnectionString("BlogDBContext"), serverVersion);
               options.EnableSensitiveDataLogging();
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio-code#update-the-database-context-class
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     var context = services.GetRequiredService<BlogDBContext>();
//     // var testPosts = new BlogPost[]{
//     //     new BlogPost(){Title="First Test", Summary="First Post in a database",Content="Some Content", Date=DateTime.Now }
//     // };

//     // context.Posts.AddRange(testPosts);
//     // context.SaveChanges();

//     // var tags = new Tag[]{
//     //     new Tag(){Text="C#"},
//     //     new Tag(){Text="C++"},
//     //     new Tag(){Text="ASP.Net"}
//     // };

//     // context.Tags.AddRange(tags);
//     // context.SaveChanges();

//     var postList = context.Posts.Where((post)=>post.Title=="First Test").Include(post=>post.Tags).ToList();
//     //var tagsList = context.Tags.AsNoTracking().Where((tag)=>tag.Text == "C#" || tag.Text == "ASP.Net").ToList();
//     var post = postList[0];
//     foreach(var tag in post.Tags){
//         Console.WriteLine(tag.Text);
//     }
//     // Console.WriteLine(postList.Count);
//     // if(postList.Count != 0){
//     //     var post = postList[0];
//     //     post.Tags = new List<Tag>();
//     //     tagsList.ForEach(tag=>{
//     //         post.Tags.Add(tag);
//     //     });
//     //     context.SaveChanges();
//     // }
    
// }


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
