using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicTacToe.Services.GameControl;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromServices] CreateGame createGame, [FromBody] CreateGame.GameViewModel gameViewModel)
        {
            if (gameViewModel == null) return BadRequest("null exp");

            return Ok(await createGame.Do(gameViewModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetMyInvitations([FromServices] GetMyInvitations getMyInvitations)
        {
            var inv = await getMyInvitations.Do();

            return Ok(inv);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptInvitation([FromServices] AcceptInvitation acceptInvitation, [FromQuery] int gameId)
        {
            return Ok(await acceptInvitation.Do(gameId));
        }

        [HttpGet]
        public IActionResult GetCurrrentGameInfo([FromServices] GetCurrentGameInformation getCurrentGameInformation, [FromQuery] int gameId)
        {
            var game = getCurrentGameInformation.Do(gameId);

            if (game == null) return BadRequest("not found");

            return Ok(game);
        }

        [HttpGet]
        public async Task<IActionResult> MakeStep([FromServices] MakeStep makeStep,[FromQuery] int gameId, [FromQuery] int val)
        {
            return Ok(await makeStep.Do(gameId, val));
        }
    }
}
