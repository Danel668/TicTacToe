using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Services.GameControl
{
    [Service]
    public class MakeStep
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext _ctx;

        public MakeStep(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ctx = ctx;
        }

        public async Task<bool> Do(int gameId, int val)
        {
            var game = _ctx.Games.Where(x => x.Id == gameId && x.Started && !x.Finished).FirstOrDefault();

            if (game == null) return false;

            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (game.Steps % 2 == 0 && game.Player1 == user.Id)
            {
                if (val >= 0 && val < 9)
                {
                    int flag = game.PointPl1 & (int)Math.Pow(2, val) | game.PointPl2 & (int)Math.Pow(2,val);

                    if (flag == 0)
                    {
                        game.PointPl1 += (int)Math.Pow(2, val);

                        int res = game.PointPl1;

                        if (res == 7 || res == 56 || res == 448 || res == 73 || res == 146 || res == 292 || res == 273 || res == 84)
                        {
                            game.Winner = user.Id;
                            game.Finished = true;
                        } else if (game.PointPl1 + game.PointPl2 == 511)
                        {
                            game.Finished = true;
                        }
                        else game.Steps++;

                        await _ctx.SaveChangesAsync();

                        return true;
                    }
                }
               
            }
           else if (game.Steps % 2 != 0 && game.Player2== user.Id)
           {
                if (val >= 0 && val < 9)
                {
                    int flag = game.PointPl1 & (int)Math.Pow(2, val) | game.PointPl2 & (int)Math.Pow(2, val);

                    if (flag == 0)
                    {
                        game.PointPl2 += (int)Math.Pow(2, val);

                        int res = game.PointPl2;

                        if (res == 7 || res == 56 || res == 448 || res == 73 || res == 146 || res == 292 || res == 273 || res == 84)
                        {
                            game.Winner = user.Id;
                            game.Finished = true;
                        } else if (game.PointPl1 + game.PointPl2 == 511)
                        {
                            game.Finished = true;
                        }
                        else game.Steps++;

                        await _ctx.SaveChangesAsync();
                        return true;
                    }
                    
                }
               
           }
            
            return false;
           
        }
    }
}
