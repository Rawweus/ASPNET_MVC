using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{

	public static AddressEntity Create()
	{
		try
		{
			return new AddressEntity();
		}
		catch { }
		return null!;
	}

	public static AddressEntity Create(string streetName, string postalCode, string city)
	{
		try
		{
			return new AddressEntity
			{
				StreetName = streetName,
				PostalCode = postalCode,
				City = city
			};
		}
		catch { }
		return null!;
	}

	public static AddressModel Create(AddressEntity entity)
	{
		try
		{
			return new AddressModel
			{
				Id = entity.Id,
				StreetName = entity.StreetName,
				PostalCode = entity.PostalCode,
				City = entity.City
			};
		}
		catch { }
		return null!;
	}
}


/* `AddressFactory.cs` ligger i `Factories`-mappen i `Infrastructure`-projektet.

Detta är en fabriksklass som skapar `AddressEntity` och `AddressModel`-objekt. 
Fabriker används för att förenkla objektskapande processer, speciellt när objektet 
behöver initieras med olika startvärden.

1. Första metoden `Create()` skapar en tom `AddressEntity`. Används när du behöver en ny, 
tom adress.

2. Andra metoden `Create(string streetName, string postalCode, string city)` 
skapar en `AddressEntity` med gatunamn, postnummer, och stad. Bra när du har 
all adressinformation.

3. Tredje metoden `Create(AddressEntity entity)` tar en `AddressEntity` och 
skapar en motsvarande `AddressModel`, vilket är användbart för att 
omvandla databasentiteter till modeller som kan användas i användargränssnittet.

Alla metoder försöker skapa och returnera objektet, men om något går fel returneras `null`. 

 */
