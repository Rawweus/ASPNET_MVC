using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
	private readonly DataContext _context = context;

	public override async Task<ResponseResult> GetAllAsync()
	{
		try
		{
			IEnumerable<UserEntity> result = await _context.Users
				.Include(i => i.Address)
				.ToListAsync();
			return ResponseFactory.Ok(result);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public override async Task<ResponseResult> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
	{
		try
		{
			var result = await _context.Set<UserEntity>()
				.Include(i => i.Address)
				.FirstOrDefaultAsync(predicate);
			if (result == null)
				return ResponseFactory.NotFound();

			return ResponseFactory.Ok(result);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

    public async Task<ResponseResult> UpdateUserBasicInfo(string userId, string phone, string bio)
    {
        try
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return ResponseFactory.NotFound();
            }

            user.Phone = phone ?? user.Phone;
			user.Bio = bio ?? user.Bio;

            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(user);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

}


/*
`UserRepository` ärver från den generiska `Repo<UserEntity>`-klassen och 
anpassar dess funktionalitet specifikt för `UserEntity`-hantering. 
Det utnyttjar `DataContext` för att kommunicera med databasen och utföra 
operationer på användardata.

- `GetAllAsync`: Asynkront hämtar alla användare från databasen inklusive 
deras adressinformation genom eager loading med `.Include(i => i.Address)`. 
Returnerar en samling av `UserEntity`-objekt eller ett felmeddelande om något går fel.
- `GetOneAsync`: Använder ett LINQ-uttryck för att asynkront hitta en specifik 
användare baserat på ett givet villkor (`predicate`). Den inkluderar användarens 
adressinformation och returnerar den hittade användaren eller indikerar 
att användaren inte finns.

Dessa metodöverlagringar tillåter detaljerad hantering av användardata 
och deras relationer, såsom att associera varje användare med deras adress. 
`ResponseFactory` används för att skapa konsekventa responsobjekt, 
vilket underlättar hantering av framgångsrika operationer och fel.
*/
