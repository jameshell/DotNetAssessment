using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.core.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.business.Services;

namespace dotnetAssessment.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Event> GetAllEvents() => _eventService.GetAllEvents();

        [HttpGet]
        [Route("{eventName}")]
        public Task<Event> GetEventByName(string eventName) => _eventService.GetEventByName(eventName);

        [HttpGet]
        [Route("Host/{devname}")]
        public Task<Event> GetEventByDeveloperName(string devName) => _eventService.GetEventByDeveloperName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddEvent([FromBody] Event ev) => _eventService.AddEvent(ev);

        [HttpDelete]
        [Route("{evId}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid evId) => _eventService.DeleteEvent(evId);
    }
}