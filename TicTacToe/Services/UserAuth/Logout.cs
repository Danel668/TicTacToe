using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services.UserAuth
{
    [Service]
    public class Logout
    {
        private SignInManager<User> _signInManager;
        public Logout(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Do()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
