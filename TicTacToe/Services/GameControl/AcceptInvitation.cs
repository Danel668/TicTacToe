using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Services.GameControl
{
    [Service]
    public class AcceptInvitation
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext _ctx;

        public AcceptInvitation(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ctx = ctx;
        }


        public async Task<bool> Do(int gameId)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var game = _ctx.Games.Where(x => x.Id == gameId && x.Player2 == user.Id && !x.Started).FirstOrDefault();

            if (game == null) return false;

            var inv = _ctx.Invitations.Where(x => x.UserId == user.Id && x.GameId == gameId).FirstOrDefault();
            inv.Accepted = true;

            game.Started = true;

            await _ctx.SaveChangesAsync();
            return true;
        }

        
    }
}
