using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models
{
    public class AccountDetailsAddressInfoModel
    {

        [Display(Name = "Address line 1", Prompt = "Enter your address line", Order = 0)]
        public string? AddressLine_1 { get; set; }

        [Display(Name = "Address line 2", Prompt = "Enter your second address line", Order = 1)]
        public string? AddressLine_2 { get; set; }

        [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
        public string? City { get; set; }

	}
}
