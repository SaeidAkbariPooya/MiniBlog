using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiniBlog.EndPoint.UI;
using MiniBlog.EndPoint.UI.Blog.Services;
using MiniBlog.EndPoint.UI.Category.Services;
using MiniBlog.EndPoint.UI.Photo.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//add and Create appsettings.json in WWROOT
string baseAddress = builder.Configuration.GetValue<string>("Url:BaseUrl");
builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});
var url = baseAddress;
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddRefitClient<ICategoryApi>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(url + "Category"))
        .SetHandlerLifetime(TimeSpan.FromMinutes(1));

builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddRefitClient<IPhotoApi>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(url + "Photo"))
        .SetHandlerLifetime(TimeSpan.FromMinutes(1));

builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddRefitClient<IBlogApi>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(url + "Blog"))
        .SetHandlerLifetime(TimeSpan.FromMinutes(1));

await builder.Build().RunAsync();
