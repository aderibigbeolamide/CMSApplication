using CMSApp.DTOs.RequestModel;
using CMSApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent([FromForm]EventRequestModel model)
        {
            var events = await _eventService.AddEvent(model);
            if (events.Success == false)
            {
                return BadRequest(events);
            }
            return Ok(events);
        }

         [HttpPut("UpdateDonation/{id}")]
        public async Task<IActionResult> UpdateDonation([FromForm]UpdateEventRequestModel model, [FromRoute]int id)
        {
            var update = await _eventService.UpdateEvent(model, id);
            if (update.Success == false)
            {
                return BadRequest(update);
            }
            return Ok(update);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var get = await _eventService.GetAllEvent();
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }

        [HttpGet("GetEventByName/{Name}")]
        public async Task<IActionResult> GetEventByName([FromRoute] string Name)
        {
            var get = await _eventService.GetEventByName(Name);
            if(get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }

        [HttpPut("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var delete = await _eventService.DeleteEvent(id);
            if (delete.Success == false)
            {
                return BadRequest(delete);
            }
            return Ok(delete);
        }
    }
}