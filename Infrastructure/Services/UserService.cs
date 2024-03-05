using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AddressService addressService)
{
	private readonly UserRepository _repository = repository;
	private readonly AddressService _addressService = addressService;


	public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
	{
		try
		{
			var exists = await _repository.AlreadyExistsAsync(x => x.Email == model.Email);
			if (exists.StatusCode == StatusCode.EXISTS)
				return exists;

			var result = await _repository.CreateOneAsync(UserFactory.Create(model));

			if (result.StatusCode != StatusCode.OK)
				return result;

			return ResponseFactory.Ok("User was created successfully.");

			
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}



	public async Task<ResponseResult> SignInUserAsync(SignInModel model)
	{
		try
		{
			var result = await _repository.GetOneAsync(x => x.Email == model.Email);
			if (result.StatusCode == StatusCode.OK && result.ContentResult != null)
			{
				var userEntity = (UserEntity)result.ContentResult;

				if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
					return ResponseFactory.Ok();
			}

			return ResponseFactory.Error("Incorrect email or password.");

		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}
}

/*
`UserService` hanterar användarrelaterade operationer såsom att skapa 
nya användare och hantera inloggning. Det använder `UserRepository` för att 
interagera med databasen och `AddressService` för att hantera adressrelaterade 
uppgifter vid behov.

- `CreateUserAsync`: Tar en `SignUpModel` och använder den för att kontrollera 
om en användare med samma e-post redan existerar. Om användaren inte existerar, 
skapas en ny användare med hjälp av `UserFactory.Create(model)` och 
sparas i databasen genom `_repository`. Returnerar en framgångsmeddelande 
eller ett fel om användaren redan finns eller om något annat fel inträffar.

- `SignInUserAsync`: Tar en `SignInModel` och försöker hitta en användare med 
angiven e-post. Om en användare hittas och lösenordet valideras framgångsrikt 
med `PasswordHasher.ValidateSecurePassword`, returneras en framgångsrespons. 
Annars returneras ett felmeddelande om att e-postadressen eller lösenordet är inkorrekt.

Dessa funktioner bidrar till att effektivisera användarhanteringen inom applikationen, 
från registrering till autentisering, och säkerställer en säker hantering av användaruppgifter.
*/
