using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

public class PasswordHasher
{
	public static (string, string) GenerateSecurePassword(string password)
	{
		using var hmac = new HMACSHA512();
		var securityKey = hmac.Key;
		var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

		return (Convert.ToBase64String(securityKey), Convert.ToBase64String(hashedPassword));
	}

	public static bool ValidateSecurePassword(string password, string hash, string securityKey)
	{
		var security = Convert.FromBase64String(securityKey);
		var pwd = Convert.FromBase64String(hash);

		using var hmac = new HMACSHA512(security);
		var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

		for(var i = 0; i < hashedPassword.Length; i++)
		{
			if (hashedPassword[i] != hash[i])
				return false;
		}
		return true;
	}
}

/*

Denna klass erbjuder metoder för att säkert hantera lösenord.

`GenerateSecurePassword` tar ett lösenord som input och genererar en 
säker hash och en säkerhetsnyckel med HMACSHA512. 
Den returnerar båda som base64-strängar. Detta används när ett nytt lösenord ska sparas.

`ValidateSecurePassword` jämför ett angivet lösenord med en sparad hash och säkerhetsnyckel. 
Den omvandlar först `securityKey` och `hash` från base64 till byte array, 
använder säkerhetsnyckeln för att skapa en HMACSHA512-hash av det angivna 
lösenordet och jämför det med den sparade hashen. Om de matchar är lösenordet korrekt.

Dessa metoder hjälper till att säkert lagra och verifiera lösenord, 
vilket är avgörande för att skydda användarinformation. 

*/
