using Events.Api.Cases.Event;
using Events.Api.Controllers.Helpers;
using Events.Api.Dto.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EventDto = Events.Api.Dto.Events.Event;


namespace Events.Api.Controllers.Event
{
    [Authorize]
    [Route("api/myEvents")]
    public class MyEventController : Controller
    {
        private readonly IEventCases _cases;

        public MyEventController(IEventCases cases)
        {
            _cases = cases;
        }

        [HttpGet]
        [Route("{userId}", Name = nameof(RouteNames.GetEventsByUserId))]
        [Produces(typeof(EventDto))]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            IActionResult result;

            var foundEvent = await _cases.GetEventsByUserId(userId);

            if (foundEvent != null)
            {
                result = Ok(foundEvent);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        [HttpPut]
        [Route("{eventId:int}")]
        public async Task<IActionResult> UpdateMyEvent([FromRoute] int eventId, [FromBody]EventUpdate eventUpdate)
        {
            await _cases.UpdateEvent(eventId, eventUpdate);

            return Ok();
        }
    }
}
