using LinqDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// register the interface and concrete class with services collection
builder.Services.AddSingleton<IAlbumList, AlbumList>();
// Add Singleton, Add Scoped, Add Transient
// Singleton We make one AlbumList and pass it around
// Scoped, We make a new album list for each CONTROLLER that asks for it
// Transient Every controller that requests the service gets a new instance of it

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
