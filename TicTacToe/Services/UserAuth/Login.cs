using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services.UserAuth
{
    [Service]
    public class Login
    {
        private SignInManager<User> _signInManager;

        public Login(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Do(LoginViewModel request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public class LoginViewModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }

   
}
