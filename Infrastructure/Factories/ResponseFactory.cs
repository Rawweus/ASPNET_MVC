using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{
	public static ResponseResult Ok()
	{
		return new ResponseResult
		{
			Message = "Succeeded",
			StatusCode = StatusCode.OK
		};
	}

	public static ResponseResult Ok(string? message = null)
	{
		return new ResponseResult
		{
			Message = message ?? "Succeeded",
			StatusCode = StatusCode.OK
		};
	}


	public static ResponseResult Ok(object obj, string? message = null)
	{
		return new ResponseResult
		{
			ContentResult = obj,
			Message = message ?? "Succeeded",
			StatusCode = StatusCode.OK
		};
	}

	public static ResponseResult Error(string? message = null)
	{
		return new ResponseResult
		{
			Message = message ?? "Failed",
			StatusCode = StatusCode.ERROR
		};
	}

	public static ResponseResult NotFound(string? message = null)
	{
		return new ResponseResult
		{
			Message = message ?? "Not found",
			StatusCode = StatusCode.NOT_FOUND
		};
	}

	public static ResponseResult Exists(string? message = null)
	{
		return new ResponseResult
		{
			Message = message ?? "Already exists",
			StatusCode = StatusCode.EXISTS
		};
	}
}


/* Har kopplingar till `ResponseResult.cs` i `Models`-mappen.

`ResponseFactory` är en hjälpklass som skapar `ResponseResult`-objekt för olika 
scenarier, som att operationen lyckades, misslyckades, resursen hittades inte, 
eller redan existerar. Detta förenklar skapandet av enhetliga responser genom applikationen.

- `Ok()` metoder skapar positiva responser, där den första overloaden ger en 
standardmeddelande, den andra låter dig anpassa meddelandet, och den tredje inkluderar 
både ett anpassat meddelande och ett objekt som responsinnehåll.
- `Error()`, `NotFound()`, och `Exists()` metoder skapar responser för felhantering 
med anpassningsbara meddelanden för varje situation.

Klasserna och metoderna i `ResponseFactory` används sannolikt genomgående i applikationen 
för att hantera API-svar eller andra typer av systemmeddelanden. 

 */
