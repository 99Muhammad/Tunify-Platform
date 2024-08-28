using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify.Model.DTO;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class IdentityUserService : IAccountUsers
    {



        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signin;

        

        public IdentityUserService(IConfiguration configuration, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signin)
        {
            this.configuration = configuration;
            userManager = _userManager;
            this.signin = signin;
           
        }




        //public Task<string> GenerateTokenAsync(IConfiguration configuration, IdentityUser user)
        //{
        //    throw new NotImplementedException();
        //}

      

        public async Task<UserDTO> LogIn(string username, string password, bool rememberMe)
        {
            var user = await userManager.FindByNameAsync(username);
            var IsValid = await userManager.CheckPasswordAsync(user, password);
         
            if (IsValid)
            {
                var roles = await userManager.GetRolesAsync(user) ?? new List<string>();

                return new UserDTO
                {
                    UserName = username,
                    
                    Roles = roles.ToList(),

                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UserDTO> Register(RegisterDTO userRegister, ModelStateDictionary modelstate)
        {
            var email = await userManager.FindByEmailAsync(userRegister.Email);
            if (email != null)
            {
                return null;
            }
            var user = new IdentityUser
            {
                UserName = userRegister.UserName,
               
                Email = userRegister.Email,
               // UserName = UserAccount.UserName,
            };
            var result = await userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await signin.SignInAsync(user, isPersistent: false);
              //  var role = await userManager.AddToRolesAsync(user, userRegister.Roles);
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,

                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(userRegister.Password) :
                                error.Code.Contains("Email") ? nameof(userRegister.Email) :
                                error.Code.Contains("UserName") ? nameof(userRegister.UserName) : string.Empty;

                if (!string.IsNullOrEmpty(errorCode))
                {
                    modelstate.AddModelError(errorCode, error.Description);
                }
                else
                {
                    modelstate.AddModelError(string.Empty, error.Description);
                }
            }

            return null;
        }

        public async Task SignOut()
        {
            await signin.SignOutAsync();
        }
    }
}
