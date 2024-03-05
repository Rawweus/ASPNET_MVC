using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class FeatureService(FeatureRepository featureRepository, FeatureItemRepository featureItemRepository)
{
	private readonly FeatureRepository _featureRepository = featureRepository;
	private readonly FeatureItemRepository _featureItemRepository = featureItemRepository;


	public async Task<ResponseResult> GetAllFeaturesAsync()
	{
		try
		{
			var result = await _featureRepository.GetAllAsync();
			return result;
		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
	}
}

/*
`FeatureService` är ansvarig för att hantera funktioner relaterade till 
'features' och 'feature items' genom att använda `FeatureRepository` och 
`FeatureItemRepository`. Detta tjänstlager tillhandahåller en abstraktion 
över datalageroperationer, vilket förenklar återanvändning och underhåll av kod.

- `GetAllFeaturesAsync`: Hämtar en lista över alla funktioner från databasen 
genom att anropa `GetAllAsync`-metoden i `FeatureRepository`. 
Om operationen lyckas returneras en lista över funktioner, annars returneras ett felmeddelande.
Detta möjliggör enkel åtkomst till samtliga funktioner för presentation 
eller vidare bearbetning inom applikationen.

*/
