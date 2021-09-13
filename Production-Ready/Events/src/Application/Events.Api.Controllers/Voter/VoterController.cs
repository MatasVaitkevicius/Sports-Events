using Events.Api.Cases.Voter;
using Events.Api.Dto.Voters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Events.Api.Controllers.Voter
{
    [Authorize]
    [Route("api/voter")]
    public class VoterController : Controller
    {
        private readonly IVoterCases _cases;

        public VoterController(IVoterCases cases)
        {
            _cases = cases;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] NewVoter newVoter)
        {
            await _cases.CreateVoter(newVoter);

            return Ok();
        }

        [HttpDelete]
        [Route("{eventId:int}/{userId}")]
        public async Task<IActionResult> Delete([FromRoute] int eventId, [FromRoute] string userId)
        {
            await _cases.DeleteVoter(eventId, userId);

            return Ok();
        }
    }
}