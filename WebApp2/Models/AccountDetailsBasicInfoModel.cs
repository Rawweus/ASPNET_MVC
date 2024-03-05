using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models
{
	public class AccountDetailsBasicInfoModel
	{
		[DataType(DataType.ImageUrl)]
		public string? ProfileImage { get; set; }

		[Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
		[Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set; } = null!;

		[Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; } = null!;

		[Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Enter a valid email address")]
		public string Email { get; set; } = null!;

		[Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
		[DataType(DataType.PhoneNumber)]
		[Required(ErrorMessage = "Phone is required")]
		public string Phone { get; set; } = null!;

		[Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
		[DataType(DataType.MultilineText)]
		public string Biography { get; set; } = null!;
	}
}


/*
`AccountDetailsBasicInfoModel` är avsedd för att hantera grundläggande personlig 
information för en användarprofil, såsom namn, e-post, telefonnummer och en kort biografi.

- `ProfileImage`: En valfri URL till en profilbild. Använder `DataType.ImageUrl` 
för att ange att det ska vara en bild-URL.

- `FirstName` och `LastName`: Användarens för- och efternamn, båda obligatoriska 
fält markerade med `Required` för att säkerställa att de fylls i.

- `Email`: Användarens e-postadress, som måste matcha ett specifikt mönster 
(`RegularExpression`) för att valideras som en giltig e-postadress.

- `Phone`: Användarens telefonnummer, markerat som obligatoriskt och ska följa 
formatet för telefonnummer (`DataType.PhoneNumber`).

- `Biography`: En valfri kort biografi om användaren, där text kan inmatas 
över flera rader (`DataType.MultilineText`).

Modellen definierar strukturen för insamling och validering av användardata 
i en användarprofil, med tydlig presentation och valideringsfeedback för slutanvändaren.
*/
