namespace Infrastructure.Entities;

public class FeatureItemEntity
{
	public int Id { get; set; }
	public int FeatureId { get; set; }
	public FeatureEntity Feature { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string Text { get; set; } = null!;

}

/* `FeatureItemEntity.cs` finns i mappen `Entities` inom projektet `Infrastructure`.

Denna klass representerar en specifik underfunktion eller ett objekt relaterat 
till en överordnad funktion (`FeatureEntity`). Den har fält för `Id`, som är den 
unika identifieraren, `FeatureId` som är en referens till den överordnade 
funktionens Id, och `Feature` som är en navigationsegenskap till den överordnade funktionen. 
Detta skapar en direkt relation mellan en underfunktion och dess överordnade funktion.

Fältet `ImageUrl` används för att lagra en URL till en bild som är associerad 
med underfunktionen, medan `Title` och `Text` används för att ge en titel 
och beskrivande text. Detta möjliggör en rik presentation av underfunktionerna 
i användargränssnittet. 

 */


// Kopplas mot en repository för att hantera dessa två entiteter ovan