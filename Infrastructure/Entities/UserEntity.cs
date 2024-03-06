using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    // Dina egna fält
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Bio { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    // AddressId och Address definieras här om du vill behålla en relation mellan användare och adresser
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}


/* `UserEntity.cs` finns i `Entities`-mappen i `Infrastructure`-projektet.

Denna klass är en användarentitet. Den håller information om användare, 
som namn, e-post, och lösenord. Varje användare har ett unikt `Id` (markerat med [Key] 
som gör det till primärnyckeln). 

`FirstName` och `LastName` är användarens för- och efternamn. 
`Email` och `Password` används för inloggning. 
`SecurityKey` är extra säkerhet. 
`Phone` och `Bio` är valfria fält för telefonnummer och en kort biografi. 
`Created` och `Modified` spårar när användaren skapades eller ändrades.

Användaren kan ha en adress, visad av `AddressId` och `Address`. 
Detta kopplar användaren till en adress i databasen. 

 */
