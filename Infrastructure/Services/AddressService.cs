using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService
{
	private readonly AddressRepository _addressRepository;

	public AddressService(AddressRepository addressRepository)
	{
		_addressRepository = addressRepository;
	}

	public async Task<ResponseResult> GetOrCreateAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{
			var address = await _addressRepository.GetAsync(addressLine1, addressLine2, postalCode, city);
			if (address == null)
			{
				address = new AddressEntity { AddressLine1 = addressLine1, AddressLine2 = addressLine2, PostalCode = postalCode, City = city };
				address = await _addressRepository.AddAsync(address);
				return ResponseFactory.Ok(address);
			}
			return ResponseFactory.Exists("Adressen finns redan.");
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public async Task<ResponseResult> CreateAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{
			// Använd _addressRepository för att kontrollera om en adress redan finns
			bool exists = await _addressRepository.AlreadyExistsAsync(a => a.AddressLine1 == addressLine1 && a.AddressLine2 == addressLine2 && a.PostalCode == postalCode && a.City == city);

			if (!exists)
			{
				// Om adressen inte finns, skapa en ny
				AddressEntity newAddress = new AddressEntity
				{
					AddressLine1 = addressLine1,
					AddressLine2 = addressLine2,
					PostalCode = postalCode,
					City = city
				};
				newAddress = await _addressRepository.AddAsync(newAddress);

				return ResponseFactory.Ok(newAddress); // Antag att detta skapar ett ResponseResult objekt med OK-status och den nya adressen
			}
			else
			{
				return ResponseFactory.Exists("Adressen finns redan."); // Antag att detta skapar ett ResponseResult objekt med Exists-status
			}
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message); // Antag att detta skapar ett ResponseResult objekt med Error-status
		}
	}

	public async Task<ResponseResult> GetAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{
			var result = await _addressRepository.GetOneAsync(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.PostalCode == postalCode && x.City == city);
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
