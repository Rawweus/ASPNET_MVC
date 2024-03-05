using Infrastructure.Entities;

namespace WebApp2.ViewModels;

public class FeatureViewModel
{
	public string Title { get; set; } = null!;
	public string Ingress { get; set; } = null!;
	public List<FeatureItemEntity> FeatureItems { get; set; } = [];
}

/*
`FeatureViewModel` är skapad för att presentera samlade funktioner inom applikationen, 
inklusive en samling av relaterade objekt eller inslag. Den innehåller:

- `Title`: En sträng som håller titeln på funktionen, vilket ger en överblick 
över vad samlingen av funktioner eller inslag handlar om.

- `Ingress`: En sträng som erbjuder en introduktion eller sammanfattning av funktionen. 
Den här texten är avsedd att ge användarna en snabb förståelse av funktionens 
kontext eller syfte.

- `FeatureItems`: En lista av `FeatureItemEntity` objekt som representerar de 
specifika inslagen eller underfunktionerna som är associerade med den övergripande funktionen. 
Detta möjliggör en detaljerad presentation av alla relaterade funktioner 
eller objekt inom samma kontext.

Denna ViewModel är användbar för att strukturera och presentera en grupperad 
samling av funktioner eller inslag till användaren, till exempel på en 
funktionssida eller i en detaljerad översikt.
*/
