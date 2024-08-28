using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Tunify.Model;
using Tunify.Model.DTO;
using Tunify.Repositories.Interfaces;

namespace Tunify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountUsers UserAccount;

        public AccountController(IAccountUsers user)
        {
            UserAccount = user;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterC(RegisterDTO registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await UserAccount.Register(registerUser, this.ModelState);

            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }

            return BadRequest();
        }


        [HttpPost("LogIn")]
        public async Task<IActionResult> Authentication(string username, string password, bool rememberMe)
        {
        
            var LogIn = await UserAccount.LogIn(username, password, rememberMe);

            if (LogIn != null)
            {
                return Ok(LogIn);
            }

            return BadRequest();
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> SignOut()
        {
            await UserAccount.SignOut();
            return Ok();
        }

    }
}
