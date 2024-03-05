using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignInModel
{
	[Display(Name = "Email address", Prompt = "Enter your email address", Order = 0)]
	[DataType(DataType.EmailAddress)]

	public string Email { get; set; } = null!;

	[Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
	[DataType(DataType.Password)]
	public string Password { get; set; } = null!;


	[Display(Name = "Remember me", Order = 2)]
	public bool RememberMe { get; set; }
}

/*

Denna klass används för att hantera data vid inloggningsförfaranden i applikationen.

Klassen innehåller tre egenskaper:
- `Email`: Användarens e-postadress. Dekorerad med `Display` och `DataType` attribut för att specificera att det är en e-postadress, samt instruktioner och ordningsföljd i användargränssnittet.
- `Password`: Användarens lösenord. Även det är dekorerat med `Display` och `DataType` attribut för att ange att det ska behandlas som ett lösenord, vilket bland annat påverkar hur det visas i gränssnittet.
- `RememberMe`: En boolsk egenskap som anger om användarens inloggningsuppgifter ska kommas ihåg för framtida besök, för att underlätta snabbare inloggning.

Denna modell används vanligtvis vid inloggningsskärmen, 
där användare fyller i sina uppgifter för att autentisera sig. 
Attributen för varje fält hjälper till att styra hur formuläret ska renderas 
och agera i användargränssnittet. 

*/
