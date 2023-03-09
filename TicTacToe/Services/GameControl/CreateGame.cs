using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Services.GameControl
{
    [Service]
    public class CreateGame
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext _ctx;

        public CreateGame(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ctx = ctx;
        }

        public async Task<bool> Do(GameViewModel gameViewModel)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var pl2 = await _userManager.FindByIdAsync(gameViewModel.Player2);

            if (pl2 == null) return false;

            if (user.Id == gameViewModel.Player2) return false;

            var game = new Game
            {
                Player1 = user.Id,
                Player2 = gameViewModel.Player2,
                Winner = null,
                Started = false,
                Steps = 0,
                PointPl1 = 0,
                PointPl2 = 0,
                Finished = false,
            };

            _ctx.Add(game);
            await _ctx.SaveChangesAsync();

            var invitation = new Invitation
            {
                UserId = gameViewModel.Player2,
                From = user.Id,
                GameId = game.Id
            };

            _ctx.Add(invitation);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public class GameViewModel
        {
            public string Player2 { get; set; }
        }
    }
}
