using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Services.GameControl
{
    [Service]
    public class GetMyInvitations
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext _ctx;

        public GetMyInvitations(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ctx = ctx;
        }

        public async Task<IEnumerable<InvitationViewModel>> Do()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            return _ctx.Invitations.Where(x => x.UserId== user.Id && !x.Accepted).Select(x => new InvitationViewModel
            {
                From = x.From,
                GameId = x.GameId,
            });

        }

        public class InvitationViewModel
        {
            public string From { get; set; }
            public int GameId { get; set; }
        }
    }
}
