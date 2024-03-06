using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities; // Säkerställ att dina entitetsbanor är korrekta

namespace Infrastructure.Contexts;

// Ändra basen till IdentityDbContext för att inkludera stöd för Identity
public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    // Behåll dina befintliga DbSet-deklarationer
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<FeatureEntity> Features { get; set; }
    public DbSet<FeatureItemEntity> FeatureItems { get; set; } // Mindre ändring i namnet för konsistens

    // Övriga konfigurationer och metodöverlagringar vid behov
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}


/* 

I din mappstruktur tillhör DataContext.cs filen mappen Contexts inom projektet Infrastructure.
Det betyder att den spelar en central roll i datalagret av din applikation, 
och fungerar som en bro mellan dina affärsobjekt (definierade i mappen Entities) 
och databasen.Den möjliggör CRUD (Create, Read, Update, Delete) operationer mot de 
tabeller som representeras av DbSet<T>-egenskaperna.

Varje DbSet<T>-egenskap i DataContext representerar en tabell i databasen. 
I din kod definierar du fyra sådana egenskaper: Addresses, Users, Features och FeatureItem.

Konstruktorn tar emot DbContextOptions<DataContext> som parameter, vilket innehåller 
konfigurationsinställningar för DataContext, såsom uppgifter om vilken databas som ska 
anslutas till.Dessa inställningar konfigureras vanligtvis i Startup.cs-filen eller där 
din applikations startup-logik finns.

*/