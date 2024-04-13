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

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    
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

