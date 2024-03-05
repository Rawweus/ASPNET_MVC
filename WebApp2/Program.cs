using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();




builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureItemRepository>();

builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FeatureService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



/*
Program.cs konfigurerar och startar webbapplikationen. Här definieras tjänster och 
middleware som applikationen använder.

- 'AddControllersWithViews()' lägger till stöd för MVC-kontrollers och vyer.

- 'AddDbContext<DataContext>()' konfigurerar Entity Framework Core för att använda 
SQL Server med en anslutningssträng definierad i applikationens konfigurationsfiler.

- 'AddScoped<>' registrerar repositories och tjänster med Scoped livstid, 
vilket innebär att en ny instans skapas per request.

- 'UseHsts()' och 'UseHttpsRedirection()' aktiverar HTTP Strict Transport Security 
och omdirigering från HTTP till HTTPS.

- 'UseStaticFiles()' tillåter applikationen att tjäna statiska filer, såsom bilder och CSS.

- 'UseRouting()' och 'UseAuthorization()' lägger till routing och auktorisation 
till requesthanteringspipelinen.

- 'MapControllerRoute()' definierar routingmönstret för MVC-kontrollers.

När konfigurationen är klar bygger 'builder.Build()' och 'app.Run()' startar webbservern som lyssnar på inkommande HTTP-förfrågningar.
*/
