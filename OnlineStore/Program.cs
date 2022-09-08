using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

var builder = WebApplication.CreateBuilder(args);



#region [- Step 2 -]
builder.Services.AddControllersWithViews();
#endregion

var app = builder.Build();

#region [- Step 8 -]
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region [- Step 11 -]
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region [- Step 3 -]
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
    endpoints.MapDefaultControllerRoute();
});
#endregion

//app.MapGet("/", () => "Hello World!");

app.Run();
