using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class User : IdentityUser
    {
        public List<Invitation> Invitations { get; set; }
    }
}
