using Events.Api.Cases.SportType;
using Events.Api.Controllers.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SportTypeDto = Events.Api.Dto.SportType.SportType;

namespace Events.Api.Controllers.SportType
{
    [Route("api/sportType")]
    public class SportTypeController : Controller
    {
        private readonly ISportTypeReadOnlyCases _cases;

        public SportTypeController(ISportTypeReadOnlyCases cases)
        {
            _cases = cases;
        }

        [HttpGet]
        [Route("", Name = nameof(RouteNames.GetAllSportTypes))]
        public async Task<SportTypeDto[]> GetAll()
        {
            return await _cases.GetAllSportTypes();
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(RouteNames.GetSportTypeById))]
        [Produces(typeof(SportTypeDto))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            IActionResult result;

            var foundEvent = await _cases.GetSportTypeById(id);

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
    }
}
