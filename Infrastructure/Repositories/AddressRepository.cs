using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
	public AddressRepository(DataContext context) : base(context)
	{
	}

	public async Task<bool> AlreadyExistsAsync(Expression<Func<AddressEntity, bool>> predicate)
	{
		return await _context.Addresses.AnyAsync(predicate);
	}

	public async Task<AddressEntity> AddAsync(AddressEntity address)
	{
		await _context.Addresses.AddAsync(address);
		await _context.SaveChangesAsync();
		return address;
	}

	public async Task<AddressEntity> GetAsync(string addressLine1, string addressLine2, string postalCode, string city)
	{
		return await _context.Addresses
			.FirstOrDefaultAsync(a => a.AddressLine1 == addressLine1
									  && a.AddressLine2 == addressLine2
									  && a.PostalCode == postalCode
									  && a.City == city);
	}
}


