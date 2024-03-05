namespace Infrastructure.Models;

public class AddressModel
{
	public int Id { get; set; }
	public string StreetName { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;
}

/*
Denna modellklass representerar strukturen för adressinformation i 
applikationens datalager och användargränssnitt.

Modellen innehåller fyra egenskaper:
- `Id`: Ett unikt identifieringsnummer för varje adress.
- `StreetName`: Gatanamnet som adressen ligger på.
- `PostalCode`: Postnumret för adressen.
- `City`: Staden där adressen finns.

`AddressModel` används för att överföra adressdata mellan olika delar av 
applikationen, till exempel mellan databasen och användargränssnittet, 
eller som en del av API-responser. Det är en del av modellagret som 
definierar hur adressdata presenteras och hanteras i systemet. 
*/
