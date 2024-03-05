using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class FeatureItemRepository(DataContext context) : Repo<FeatureItemEntity>(context)
{
	private readonly DataContext _context = context;
}

/*
`FeatureItemRepository` är avsett för att hantera databasinteraktioner för 
`FeatureItemEntity`-objekt. Precis som `AddressRepository`, ärver denna klass 
från en bas `Repo`-klass som tillhandahåller generiska CRUD-operationer, 
anpassade för att arbeta med `FeatureItemEntity`-objekt.

- `_context` är en instans av `DataContext` som används internt i repositoryt 
för att genomföra databasoperationer. Detta gör det möjligt för `FeatureItemRepository` 
att utföra specifika operationer relaterade till `FeatureItemEntity`-objekt, 
som att hämta, skapa, uppdatera eller radera funktionselement i databasen.

Denna klass spelar en viktig roll i applikationens arkitektur genom att den 
abstraherar bort de direkt databasoperationerna från applikationslogiken, 
vilket möjliggör en renare och mer återanvändbar kod.
*/
