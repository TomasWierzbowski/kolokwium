using kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly IDbService _dbService;
        public TeamsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{TeamID}")]
        public async Task<ActionResult> GetTeam(int TeamID)
        {

            var team = await _dbService.GetTeam(TeamID);
            return Ok(team);

        }

    }
}
