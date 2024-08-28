using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify.Model.DTO;

namespace Tunify.Repositories.Interfaces
{
    public interface IAccountUsers
    {
      public  Task<UserDTO> Register(RegisterDTO user, ModelStateDictionary modelstate);
        Task<UserDTO> LogIn(string username, string password, bool rememberMe);
        Task SignOut();

        public Task<string> GenerateTokenAsync(IConfiguration configuration, IdentityUser user);


    }
}
