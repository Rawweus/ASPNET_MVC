using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AddressService _addressService;

        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _addressService = addressService;
        }

        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {
            try
            {
                var user = new UserEntity
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    // Andra fält från SignUpModel kan tilldelas här
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return ResponseFactory.Ok("User was created successfully.");
                }

                return ResponseFactory.Error(string.Join(";", result.Errors.Select(e => e.Description)));
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> SignInUserAsync(SignInModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return ResponseFactory.Ok();
            }
            else if (result.IsLockedOut)
            {
                return ResponseFactory.Error("User account locked.");
            }
            else
            {
                return ResponseFactory.Error("Incorrect email or password.");
            }
        }

        public async Task<ResponseResult> UpdateUserAsync(string userId, string phone, string bio)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseFactory.Error("User not found.");
            }

            // Uppdatera fälten om de inte är null eller tomma.
            if (!string.IsNullOrWhiteSpace(phone))
            {
                user.Phone = phone;
            }
            if (!string.IsNullOrWhiteSpace(bio))
            {
                user.Bio = bio;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return ResponseFactory.Ok("User information updated successfully.");
            }

            return ResponseFactory.Error(string.Join(";", result.Errors.Select(e => e.Description)));
        }

    }
}

/*
`UserService` hanterar användarrelaterade operationer såsom att skapa 
nya användare och hantera inloggning. Det använder `UserRepository` för att 
interagera med databasen och `AddressService` för att hantera adressrelaterade 
uppgifter vid behov.

- `CreateUserAsync`: Tar en `SignUpModel` och använder den för att kontrollera 
om en användare med samma e-post redan existerar. Om användaren inte existerar, 
skapas en ny användare med hjälp av `UserFactory.Create(model)` och 
sparas i databasen genom `_repository`. Returnerar en framgångsmeddelande 
eller ett fel om användaren redan finns eller om något annat fel inträffar.

- `SignInUserAsync`: Tar en `SignInModel` och försöker hitta en användare med 
angiven e-post. Om en användare hittas och lösenordet valideras framgångsrikt 
med `PasswordHasher.ValidateSecurePassword`, returneras en framgångsrespons. 
Annars returneras ett felmeddelande om att e-postadressen eller lösenordet är inkorrekt.

Dessa funktioner bidrar till att effektivisera användarhanteringen inom applikationen, 
från registrering till autentisering, och säkerställer en säker hantering av användaruppgifter.
*/
