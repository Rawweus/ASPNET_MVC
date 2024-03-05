namespace Infrastructure.Entities;

public class FeatureEntity
{
	public int Id { get; set; }

	public string Title { get; set; } = null!;

	public string Ingress { get; set; } = null!;

	public ICollection<FeatureItemEntity> FeatureItems { get; set; } = [];
}


/* `FeatureEntity.cs` finns i mappen `Entities` inom projektet `Infrastructure`.

Denna klass representerar en "feature" eller funktion i systemet, med fält för `Id`, 
`Title` och `Ingress`. `Id` fungerar som entitetens unika identifierare. 
`Title` och `Ingress` används för att ge namn och en kort beskrivning av funktionen.

`FeatureItems` är en samling av `FeatureItemEntity`, vilket indikerar en 
relation där en funktion kan ha flera underfunktioner eller objekt associerade med sig. 
Denna samling tillåter navigering från en funktion till dess relaterade 
underfunktioner i databasen. 

 */
