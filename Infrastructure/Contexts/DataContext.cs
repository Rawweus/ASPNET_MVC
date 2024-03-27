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
	public DbSet<FeatureItemEntity> FeatureItems { get; set; }

	// Övriga konfigurationer och metodöverlagringar vid behov
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Konfigurera en-till-en-relationen mellan UserEntity och AddressEntity
		builder.Entity<UserEntity>()
			.HasOne(u => u.Address) // UserEntity har en Address
			.WithOne() // AddressEntity har en eller ingen UserEntity
			.HasForeignKey<UserEntity>(u => u.AddressId) // AddressId i UserEntity är ForeignKey
			.IsRequired(false); // Gör detta om adressen är valfri
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