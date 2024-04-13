using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService
{
	private readonly AddressRepository _addressRepository;

	public AddressService(AddressRepository addressRepository)
	{
		_addressRepository = addressRepository;
	}

	public async Task<ResponseResult> GetOrCreateAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{
			var address = await _addressRepository.GetAsync(addressLine1, addressLine2, postalCode, city);
			if (address == null)
			{
				address = new AddressEntity { AddressLine1 = addressLine1, AddressLine2 = addressLine2, PostalCode = postalCode, City = city };
				address = await _addressRepository.AddAsync(address);
				return ResponseFactory.Ok(address);
			}
			return ResponseFactory.Exists("Adressen finns redan.");
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public async Task<ResponseResult> CreateAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{

			bool exists = await _addressRepository.AlreadyExistsAsync(a => a.AddressLine1 == addressLine1 && a.AddressLine2 == addressLine2 && a.PostalCode == postalCode && a.City == city);

			if (!exists)
			{

				AddressEntity newAddress = new AddressEntity
				{
					AddressLine1 = addressLine1,
					AddressLine2 = addressLine2,
					PostalCode = postalCode,
					City = city
				};
				newAddress = await _addressRepository.AddAsync(newAddress);

				return ResponseFactory.Ok(newAddress);
			}
			else
			{
				return ResponseFactory.Exists("Adressen finns redan."); 
			}
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message); 
		}
	}

	public async Task<ResponseResult> GetAddressAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		try
		{
			var result = await _addressRepository.GetOneAsync(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.PostalCode == postalCode && x.City == city);
			return result;
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}
}

