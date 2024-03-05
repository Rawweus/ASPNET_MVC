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
Program.cs konfigurerar och startar webbapplikationen. H�r definieras tj�nster och 
middleware som applikationen anv�nder.

- 'AddControllersWithViews()' l�gger till st�d f�r MVC-kontrollers och vyer.

- 'AddDbContext<DataContext>()' konfigurerar Entity Framework Core f�r att anv�nda 
SQL Server med en anslutningsstr�ng definierad i applikationens konfigurationsfiler.

- 'AddScoped<>' registrerar repositories och tj�nster med Scoped livstid, 
vilket inneb�r att en ny instans skapas per request.

- 'UseHsts()' och 'UseHttpsRedirection()' aktiverar HTTP Strict Transport Security 
och omdirigering fr�n HTTP till HTTPS.

- 'UseStaticFiles()' till�ter applikationen att tj�na statiska filer, s�som bilder och CSS.

- 'UseRouting()' och 'UseAuthorization()' l�gger till routing och auktorisation 
till requesthanteringspipelinen.

- 'MapControllerRoute()' definierar routingm�nstret f�r MVC-kontrollers.

N�r konfigurationen �r klar bygger 'builder.Build()' och 'app.Run()' startar webbservern som lyssnar p� inkommande HTTP-f�rfr�gningar.
*/
