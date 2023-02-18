using WunderVisionBlog2.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MariaDbServerVersion(new Version(15,1));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WunderVisionBlog2.Models.BlogDBContext>(options=>{
               options.UseMySql(builder.Configuration.GetConnectionString("BlogDBContext"), serverVersion);
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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BlogDBContext>();
    var testPosts = new BlogPost[]{
        new BlogPost(){Title="First Test", Summary="First Post in a database",Content="Some Content", Date=DateTime.Now }
    };

    context.Posts.AddRange(testPosts);
    context.SaveChanges();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
