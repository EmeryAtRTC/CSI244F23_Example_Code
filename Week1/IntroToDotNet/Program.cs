WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// If you are adding databases, ecryption, email services
// Adding services to the service collection
builder.Services.AddControllersWithViews();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// Allows us to use a more detailed error page while in development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//building has Configuration object that contains all the info from appsettings.json
string apikey = builder.Configuration.GetValue<string>("APIKey");
Console.WriteLine($"The apikey is {apikey}");
//This is where we add middleware

app.UseHttpsRedirection();
//This allows us to serve static (a plan .html file)
app.UseStaticFiles();

app.UseRouting();

//This allows for authorization
app.UseAuthorization();

//This turns on routing and it defines the following template for routing
// webserver/controllerName/ActionName
//lets go explore the HomeController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
