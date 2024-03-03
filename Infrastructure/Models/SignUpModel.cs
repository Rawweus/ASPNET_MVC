using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpModel
{
	[DataType(DataType.Text)]
	[Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
	[Required(ErrorMessage = "Invalid first name")]
	public string FirstName { get; set; } = null!;

	[DataType(DataType.Text)]
	[Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
	[Required(ErrorMessage = "Invalid last name")]
	public string LastName { get; set; } = null!;

	[DataType(DataType.EmailAddress)]
	[Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
	[RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Enter a valid email address")]
	public string Email { get; set; } = null!;

	[DataType(DataType.Password)]
	[Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Enter a valid password")]
	public string Password { get; set; } = null!;

	[DataType(DataType.Password)]
	[Display(Name = "Confirm password", Prompt = "Confirm password", Order = 4)]
	[Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
	public string ConfirmPassword { get; set; } = null!;

	[Display(Name = "I agree to the Terms & Conditions", Order = 5)]
	[CheckBoxRequired(ErrorMessage = "You must agree to the terms & conditions")]
	public bool TermsAndConditions { get; set; } = false;
}
