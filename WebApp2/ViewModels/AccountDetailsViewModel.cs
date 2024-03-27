using WebApp2.Models;

namespace WebApp2.ViewModels
{
	public class AccountDetailsViewModel
	{
		public AccountDetailsBasicInfoModel? BasicInfo { get; set; }
		public AccountDetailsAddressInfoModel? AddressInfo { get; set; }
	}
}

/*
`AccountDetailsViewModel` samlar information för både grundläggande 
personuppgifter och adressuppgifter i en användarprofil. 
Den agerar som en container för att föra samman:

- `BasicInfo`: En instans av `AccountDetailsBasicInfoModel` som innehåller 
användarens grundläggande information såsom namn, e-post, telefonnummer och biografi.

- `AddressInfo`: En instans av `AccountDetailsAddressInfoModel` 
som innehåller adressinformation såsom gatuadress, postnummer och stad.

Denna ViewModel förenklar hanteringen av användardata genom att 
gruppera dessa två informationskategorier under en enda modell, 
vilket gör det enklare att överföra data mellan kontrollern och vyn i en MVC-applikation.
*/
