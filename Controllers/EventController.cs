using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.Repositories;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Event> GetAllEvents() => _eventRepository.GetAll();

        [HttpGet]
        [Route("{eventName}")]
         public Task<Event> GetEventByName(string eventName) => _eventRepository.GetEventByName(eventName);

        [HttpGet]
        [Route("Host/{devname}")]
         public Task<Event> GetEventByDeveloperName(string devname) => _eventRepository.GetEventByDeveloperName(devname);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddEvent([FromBody] Event ev) => _eventRepository.Insert(ev);

        [HttpDelete]
        [Route("{evId}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid evId) => _eventRepository.Delete(evId);
    }
}