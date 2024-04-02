using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Lägg till stöd för kontroller och vyer
builder.Services.AddControllersWithViews();

// Konfigurera databaskontexten för att använda SQL Server
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Uppdatera från IdentityUser till din anpassade UserEntity
builder.Services.AddDefaultIdentity<UserEntity>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>();


// Registrera dina repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureItemRepository>();

// Registrera dina tjänster
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FeatureService>();



var app = builder.Build();


app.UseCors(builder =>
    builder.WithOrigins("http://localhost:{7234}") // Ersätt {PORT} med porten för din MVC-applikation
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseStatusCodePagesWithReExecute("/error", "statusCode={0}");

// Konfigurera HTTP Strict Transport Security Protocol
app.UseHsts();

// Konfigurera HTTPS-omdirigering
app.UseHttpsRedirection();

// Aktivera tjänst för statiska filer
app.UseStaticFiles();

// Aktivera routing
app.UseRouting();

// Aktivera autentisering och auktorisering
app.UseAuthentication();
app.UseAuthorization();

// Konfigurera standardrutten
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Starta applikationen
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
