using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService(AddressRepository repository)
{
	private readonly AddressRepository _repository = repository;

	public async Task<ResponseResult> GetOrCreateAddressAsync(string streetName, string postalCode, string city)
	{
		try
		{
			var result = await GetAddressAsync(streetName, postalCode, city);
			if (result.StatusCode == StatusCode.NOT_FOUND)
				result = await CreateAddressAsync(streetName, postalCode, city);

			return result;
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}

	public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
	{
		try
		{
			var exists = await _repository.AlreadyExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
			if (exists == null)
			{
				var result = await _repository.CreateOneAsync(AddressFactory.Create(streetName, postalCode, city));
				if (result.StatusCode == StatusCode.OK)
					return ResponseFactory.Ok(AddressFactory.Create((AddressEntity)result.ContentResult!));

				return result;
			}

			return exists;
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}

	public async Task<ResponseResult> GetAddressAsync(string streetName, string postalCode, string city)
	{
		try
		{
			var result = await _repository.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
			return result;
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}
}

/*
`AddressService` använder `AddressRepository` för att hantera adressrelaterade 
operationer som att hämta eller skapa adresser. Detta service-lager förenklar 
interaktionen mellan applikationens användargränssnitt/logik och datalagret.

- `GetOrCreateAddressAsync`: Försöker först hitta en befintlig adress med 
angivna parametrar. Om adressen inte finns, skapas en ny adress. 
Detta säkerställer att adresser inte dupliceras i databasen.

- `CreateAddressAsync`: Skapar en ny adress efter att ha kontrollerat att en 
likadan adress inte redan existerar i databasen. Använder `AddressFactory` 
för att skapa adressobjekt och `AddressRepository` för att spara adressen. 
Returnerar den skapade adressen eller ett felmeddelande.

- `GetAddressAsync`: Söker efter en adress baserat på gatunamn, postnummer och stad. 
Returnerar adressen om den hittas, annars ett meddelande om att adressen inte kunde hittas.

Dessa metoder bidrar till att effektivisera hanteringen av adressdata, vilket 
underlättar skapandet av nya adresser och sökning efter befintliga adresser 
utan att introducera duplicering.
*/
