using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tunify.Model.DTO;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class IdentityUserService : IAccountUsers
    {
        private readonly jwtTokenService jwtTokenService;


        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signin;

        

        public IdentityUserService(IConfiguration configuration, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signin, jwtTokenService jwtTokenService)
        {
            this.configuration = configuration;
            userManager = _userManager;
            this.signin = signin;
            this.jwtTokenService = jwtTokenService;

        }


        public async Task<string> GenerateTokenAsync(IConfiguration configuration, IdentityUser user)
        {

            var userPrincipal = await signin.CreateUserPrincipalAsync(user);
            if (userPrincipal == null)
            {
                return null;
            }

            var identity = (ClaimsIdentity)userPrincipal.Identity;


            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));


            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }


            return jwtTokenService.GenerateToken(userPrincipal);
        }



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
                    Token = await GenerateTokenAsync(configuration, user),
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
                var role = await userManager.AddToRolesAsync(user, userRegister.Roles);
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
