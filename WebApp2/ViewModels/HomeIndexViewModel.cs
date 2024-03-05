using Infrastructure.Entities;
using Infrastructure.Services;

namespace WebApp2.ViewModels;

public class HomeIndexViewModel
{
	private readonly FeatureService _featureService;

	public HomeIndexViewModel(FeatureService featureService)
	{
		_featureService = featureService;

		Task.Run(async () =>
		{
			var result = await _featureService.GetAllFeaturesAsync();
			var content = (FeatureEntity)result.ContentResult!;

			Features.Title = content.Title;
			Features.Ingress = content.Ingress;

			foreach(var item in content.FeatureItems)
				Features.FeatureItems.Add(item);
		});

	}

	public FeatureViewModel Features { get; set; } = new FeatureViewModel();
}

/*
`HomeIndexViewModel` använder `FeatureService` för att hämta information om olika 
funktioner så fort den startas. Tänk dig att det är som att direkt när du 
öppnar en app, så börjar den leta efter de senaste nyheterna att visa upp för dig.

- När `HomeIndexViewModel` skapas, ber den genast `FeatureService` att 
ge den en lista med funktioner.
- Så snart den får informationen, fyller den en del av sig själv, som heter `Features`, 
med denna information. `Features` håller på saker som namnet på funktionen, 
en kort beskrivning, och en lista med detaljerade punkter om funktionen.
- Det här gör att all information om funktionerna är redo att visas på hemsidan 
så snart du kommer dit.

Med andra ord, den här koden ser till att allt är förberett och redo för 
att visa upp de senaste funktionerna för dig på hemsidan utan dröjsmål.
*/

