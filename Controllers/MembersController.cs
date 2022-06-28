using kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IDbService _dbService;
        public MembersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddMember(int IdMusician)
        //{
        //    var added = await _dbService.AddMember(IdMusician);

        //    if (added)
        //    {
        //        return Ok("Member has been deleted");
        //    }
        //    else
        //    {
        //        return BadRequest("Cannot add member");
        //    }
        //}

    }
}
