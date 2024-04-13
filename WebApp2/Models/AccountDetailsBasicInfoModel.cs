using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models
{
	public class AccountDetailsBasicInfoModel
	{
		[DataType(DataType.ImageUrl)]
		public string? ProfileImage { get; set; }

		[Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
		public string? FirstName { get; set; }

		[Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
		public string? LastName { get; set; }

		[Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
		[DataType(DataType.EmailAddress)]
	
		public string? Email { get; set; }

		[Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
		[DataType(DataType.PhoneNumber)]
		public string? Phone { get; set; }

		[Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
		[DataType(DataType.MultilineText)]
		public string? Biography { get; set; }
	}
}

