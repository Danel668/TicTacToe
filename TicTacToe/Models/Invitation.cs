namespace TicTacToe.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string From { get; set; }
        public bool Accepted { get; set; }
    }
}
