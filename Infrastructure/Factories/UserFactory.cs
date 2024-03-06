using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;
using System.Net.NetworkInformation;

namespace Infrastructure.Factories;

public class UserFactory
{
	public static UserEntity Create()
	{
		try
		{
			var date = DateTime.Now;

			return new UserEntity() { 
				Id = Guid.NewGuid().ToString(),
				Created = date,
				Modified = date
			};
		}
		catch { }
		return null!;
	}

	public static UserEntity Create(SignUpModel model)
	{
		try
		{
			var date = DateTime.Now;
			var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);


			return new UserEntity
			{
				Id = Guid.NewGuid().ToString(),
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Created = date,
				Modified = date
			};
		}
		catch { }
		return null!;
	}

}

/* Är kopplad till `UserEntity.cs` i `Entities`-mappen samt `SignUpModel.cs` i `Models`-mappen. Den använder även `PasswordHasher.cs` från `Helpers`-mappen.

`UserFactory` skapar `UserEntity`-objekt. Det finns två överbelastningar av `Create`-metoden:
1. Den första skapar en tom användarentitet med ett unikt GUID som `Id` 
och sätter `Created` och `Modified` till nuvarande datum och tid.

2. Den andra tar emot ett `SignUpModel`, använder det för att fylla i 
användarinformation som förnamn, efternamn, och e-post. Den använder `PasswordHasher` 
för att generera ett säkert lösenord och säkerhetsnyckel, och sätter också `Created` 
och `Modified` till nuvarande datum och tid.

Dessa metoder underlättar skapandet av nya användare, 
antingen helt tomma eller baserade på registreringsdata. 

 */

