namespace WebApp2.ViewModels;

public class FeatureItemViewModel
{
	public string Image { get; set; } = null!;

	public string Title { get; set; } = null!;

	public string? Text { get; set; }
}

/*
`FeatureItemViewModel` är designad för att representera en funktion eller ett inslag 
i applikationen, med möjlighet att inkludera en bild, en titel och en valfri 
beskrivningstext. Den används för att modellera data på ett sådant sätt 
att det kan presenteras användarvänligt i användargränssnittet.

Denna ViewModel är användbar för att organisera och visa information om 
specifika funktioner eller inslag inom applikationen, till exempel i listor 
eller informationspaneler.
*/
