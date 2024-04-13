using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{

	public static AddressEntity Create()
	{
		try
		{
			return new AddressEntity();
		}
		catch { }
		return null!;
	}

	public static AddressEntity Create(string addressLine1, string addressLine2, string postalCode, string city)
	{
		{
			try
			{
				return new AddressEntity
				{
					AddressLine1 = addressLine1,
					AddressLine2 = addressLine2,
					PostalCode = postalCode,
					City = city
				};
			}
			catch { }
			return null!;
		}
	}

		public static AddressModel Create(AddressEntity entity)
		{
			try
			{
				return new AddressModel
				{
					Id = entity.Id,
					AddressLine1 = entity.AddressLine1,
					AddressLine2 = entity.AddressLine2,
					PostalCode = entity.PostalCode,
					City = entity.City
				};
			}
			catch { }
			return null!;
		}

	}


