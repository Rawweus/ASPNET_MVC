using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity
{
	[Key]
	public int Id { get; set; }
	public string StreetName { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;

	public ICollection<UserEntity> Users { get; set; } = [];
}

/* `AddressEntity.cs` tillhör mappen `Entities` i projektet `Infrastructure`. 

Den här klassen representerar en adressentitet med fält för 
`Id`, `StreetName`, `PostalCode`, och `City`. 
Attributet `[Key]` markerar `Id`-fältet som primärnyckel i databastabellen. 
`Users`-egenskapen är en samling av `UserEntity`, vilket antyder en 
relation mellan adresser och användare, där en adress kan associeras med flera användare. 

 */
