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


/*

`AddressRepository` är en del av `Repositories`-mappen och ärver från en generisk 
`Repo`-klass som hanterar CRUD-operationer för `AddressEntity`. 
Denna klass tar emot en `DataContext` vid instansiering, vilket gör att 
den kan interagera med databasen för adressrelaterade operationer.

- `_context`: En privat readonly-fält som håller en instans av `DataContext`. 
Detta används för att utföra databasoperationer relaterade till adressentiteter.

`AddressRepository` utgör en bro mellan databasen och applikationslogiken, 
där specifika databasoperationer för adressentiteter kan definieras och hanteras.

*/
