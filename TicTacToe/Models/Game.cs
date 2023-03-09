
namespace TicTacToe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public string Winner { get; set; }
        public bool Finished { get; set; }
        public int Steps { get; set; }

        public int PointPl1 { get; set; } = 0;
        public int PointPl2 { get; set; } = 0;
        public bool Started { get; set; }
        
    }
}
