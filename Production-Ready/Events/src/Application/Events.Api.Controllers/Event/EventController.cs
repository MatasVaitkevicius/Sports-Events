using Events.Api.Cases.Event;
using Events.Api.Controllers.Helpers;
using Events.Api.Dto.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EventDto = Events.Api.Dto.Events.Event;

namespace Events.Api.Controllers.Event
{
    [Route("api/events")]
    public class EventController : Controller
    {
        private readonly IEventCases _cases;

        public EventController(IEventCases cases)
        {
            _cases = cases;
        }

        [HttpGet]
        [Route("", Name = nameof(RouteNames.GetAllEvents))]
        public async Task<EventDto[]> GetAll()
        {
            return await _cases.GetAllEvents();
        }

        [HttpGet]
        [Route("search/{searchTerm}", Name = nameof(RouteNames.GetAllEventsBySearchTerm))]
        public async Task<EventDto[]> GetAllEventsBySearchTerm([FromRoute] string searchTerm)
        {
            return await _cases.GetAllEventsBySearchTerm(searchTerm);
        }

        [HttpGet]
        [Route("sportType/{sportTypeId:int}", Name = nameof(RouteNames.GetAllEventsBySportTypeId))]
        public async Task<EventDto[]> GetAllEventsBySportTypeId([FromRoute] int sportTypeId)
        {
            return await _cases.GetAllEventsBySportTypeId(sportTypeId);
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(RouteNames.GetEventById))]
        [Produces(typeof(EventDto))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            IActionResult result;

            var foundEvent = await _cases.GetEventById(id);

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

        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] NewEvent newEvent)
        {
            var eventId = await _cases.CreateEvent(newEvent);

            var uri = new Uri(Url.Link(nameof(RouteNames.GetEventById), new { id = eventId }));

            return Created(uri, null);
        }

        [Authorize]
        [HttpPut]
        [Route("{eventId:int}/state")]
        public async Task<IActionResult> ChangeState([FromRoute] int eventId)
        {
            await _cases.ChangeEventState(eventId);

            return Ok();
        }
    }
}