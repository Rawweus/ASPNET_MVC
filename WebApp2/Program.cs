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

// L�gg till st�d f�r kontroller och vyer
builder.Services.AddControllersWithViews();

// Konfigurera databaskontexten f�r att anv�nda SQL Server
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Uppdatera fr�n IdentityUser till din anpassade UserEntity
builder.Services.AddDefaultIdentity<UserEntity>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>();


// Registrera dina repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureItemRepository>();

// Registrera dina tj�nster
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FeatureService>();



var app = builder.Build();


app.UseCors(builder =>
    builder.WithOrigins("http://localhost:{7234}") // Ers�tt {PORT} med porten f�r din MVC-applikation
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseStatusCodePagesWithReExecute("/error", "statusCode={0}");

// Konfigurera HTTP Strict Transport Security Protocol
app.UseHsts();

// Konfigurera HTTPS-omdirigering
app.UseHttpsRedirection();

// Aktivera tj�nst f�r statiska filer
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
