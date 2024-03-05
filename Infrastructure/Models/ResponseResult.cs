
namespace Infrastructure.Models;

public enum StatusCode
{
	OK = 200,
	ERROR = 400,
	NOT_FOUND = 404,
	EXISTS = 409,

}
public class ResponseResult
{
	public StatusCode StatusCode { get; set; }
	public object? ContentResult { get; set; }
	public string? Message { get; set; }

}

/*

Dessa statusar används för att standardisera svar från applikationens backend till 
frontend eller externa anropare.

`StatusCode` är en enum som definierar olika typer av HTTP-statuskoder 
som applikationen kan returnera:
- `OK` för lyckade operationer (200).
- `ERROR` för generella fel (400).
- `NOT_FOUND` när en resurs inte kan hittas (404).
- `EXISTS` när en resurs redan existerar och skapandet misslyckas (409).

`ResponseResult` är en klass som innehåller tre egenskaper:
- `StatusCode`: Enum-värdet som beskriver svarets typ.
- `ContentResult`: Eventuellt innehåll eller data som ska skickas tillbaka med svaret. Detta fält är valfritt och kan innehålla olika datatyper.
- `Message`: En valfri textsträng som kan förklara svaret eller ge ytterligare information.

Denna struktur används för att skapa enhetliga och förutsägbara svar 
genom applikationens olika delar, vilket underlättar felhantering och 
kommunikation mellan server och klient. 

 */
