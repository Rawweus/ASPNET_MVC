using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FeatureRepository(DataContext context) : Repo<FeatureEntity>(context)
{
	private readonly DataContext _context = context;

	public override async Task<ResponseResult> GetAllAsync()
	{
		try
		{
			IEnumerable<FeatureEntity> result = await _context.Features
				.Include(i => i.FeatureItems)
				.ToListAsync();
			return ResponseFactory.Ok(result);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}
}

/*

`FeatureRepository` hanterar databasoperationer för `FeatureEntity`-objekt 
och ärver från bas `Repo`-klassen som tillhandahåller generella CRUD-funktioner. 
Detta repository utökar funktionaliteten genom att implementera en anpassad `GetAllAsync`-metod.

- `_context`: En privat readonly-instans av `DataContext` som används 
för att interagera med databasen.

Metoden `GetAllAsync` är asynkron och hämtar alla `FeatureEntity`-objekt 
inklusive deras relaterade `FeatureItemEntity`-objekt genom eager loading 
med `.Include(i => i.FeatureItems)`. Den returnerar en `ResponseResult` som antingen 
innehåller en lista av alla funktioner vid framgång eller ett felmeddelande vid undantag.

`ResponseFactory` används för att skapa en enhetlig responsstruktur för operationen, 
där `Ok` används för att signalera framgång och `Error` för att hantera fel, 
inklusive undantagets meddelande.

*/
