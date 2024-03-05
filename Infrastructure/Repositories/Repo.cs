using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
	private readonly DataContext _context;

	protected Repo(DataContext context)
	{
		_context = context;
	}

	// SOLID	SRP Single Responsibility Principle
	//Koden nedan ska bara skapa något som den sparar i databasen. Ingenting annat.
	public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return ResponseFactory.Ok(entity);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}

	}

	public virtual async Task<ResponseResult> GetAllAsync()
	{
		try
		{
			IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
			return ResponseFactory.Ok(result);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}

	}

	public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (result == null)
				return ResponseFactory.NotFound();
					
			return ResponseFactory.Ok(result);
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
	{
		try
		{
			var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (result != null)
			{
				_context.Entry(result).CurrentValues.SetValues(updatedEntity);
				await _context.SaveChangesAsync();
				return ResponseFactory.Ok(result);
			}

			return ResponseFactory.NotFound();
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (result != null)
			{
				_context.Set<TEntity>().Remove(result);
				await _context.SaveChangesAsync();
				return ResponseFactory.Ok("Successfully removed");
			}

			return ResponseFactory.NotFound();
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var result = await _context.Set<TEntity>().AnyAsync(predicate);
			if (result)
				return ResponseFactory.Exists();

			return ResponseFactory.NotFound();
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}
}


/*
`Repo<TEntity>` är en abstrakt basrepositoryklass som definierar en uppsättning 
asynkrona CRUD-operationer (Skapa, Läsa, Uppdatera, Radera) för en generell 
entitetstyp `TEntity`. Denna klass följer Single Responsibility Principle (SRP) 
från SOLID-principerna genom att varje metod ansvarar för en specifik typ av databasoperation. 

Klassen använder `DataContext` för databasinteraktion och `ResponseFactory` 
för att skapa enhetliga responsobjekt.

- `CreateOneAsync`: Lägger till en ny entitet i databasen och returnerar den 
sparade entiteten om operationen lyckas, annars returneras ett felmeddelande.

- `GetAllAsync`: Hämtar alla entiteter av typen `TEntity` från databasen och 
returnerar dem som en samling, eller ett felmeddelande vid undantag.

- `GetOneAsync`: Använder ett LINQ-uttryck (`Expression<Func<TEntity, bool>>`) 
som predikat för att hitta en specifik entitet. Returnerar den hittade entiteten 
eller indikerar att den inte finns.

- `UpdateOneAsync`: Uppdaterar en befintlig entitet baserat på ett predikat. 
Om entiteten finns uppdateras den med de nya värdena från `updatedEntity`.

- `DeleteOneAsync`: Tar bort en entitet som matchar det angivna predikatet från 
databasen och returnerar ett meddelande om framgång, eller indikerar 
att entiteten inte kunde hittas.

- `AlreadyExistsAsync`: Kontrollerar om det finns någon entitet som uppfyller 
det angivna predikatet, användbart för att validera unika data innan insättning.

Denna struktur tillåter återanvändning och flexibilitet i hanteringen av 
olika entitetstyper, samtidigt som den förenklar skapandet av responsobjekt 
för kommunikation med applikationens andra delar.
*/
