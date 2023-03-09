using System.Linq;
using TicTacToe.Data;

namespace TicTacToe.Services.GameControl
{
    [Service]
    public class GetCurrentGameInformation
    {
        private ApplicationDbContext _ctx;

        public GetCurrentGameInformation( ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public GameInfoViewModel Do(int gameId)
        {
            return _ctx.Games.Where(x => x.Id == gameId).Select(x => new GameInfoViewModel
            {
                Id = x.Id,
                Player1= x.Player1,
                Player2= x.Player2,
                Winner = x.Winner,
                Finished = x.Finished,
                Steps = x.Steps,
                PointPl1 = x.PointPl1,
                PointPl2 = x.PointPl2,
                Started= x.Started,
            }).FirstOrDefault();
        }

        public class GameInfoViewModel
        {
            public int Id { get; set; }
            public string Player1 { get; set; }
            public string Player2 { get; set; }
            public string Winner { get; set; }
            public bool Finished { get; set; }
            public int Steps { get; set; }

            public int PointPl1 { get; set; }
            public int PointPl2 { get; set; }
            public bool Started { get; set; }
        }
    }
}
