using WebApp2.Models;

namespace WebApp2.ViewModels
{
	public class AccountDetailsViewModel
	{
		public AccountDetailsBasicInfoModel BasicInfo { get; set; } = null!;
		public AccountDetailsAddressInfoModel AddressInfo { get; set; } = null!;
	}
}
