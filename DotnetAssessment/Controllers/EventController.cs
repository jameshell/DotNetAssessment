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
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<EventController> _logger;

        public EventController(IUnitOfWork unitOfWork, ILogger<EventController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Event> GetAllEvents() => _unitOfWork.EventRepository.GetAll();

        [HttpGet]
        [Route("{eventName}")]
        public Task<Event> GetEventByName(string eventName) => _unitOfWork.EventRepository.GetEventByName(eventName);

        [HttpGet]
        [Route("Host/{devname}")]
        public Task<Event> GetEventByDeveloperName(string devname) => _unitOfWork.EventRepository.GetEventByDeveloperName(devname);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddEvent([FromBody] Event ev)
        {
            try
            {
                _unitOfWork.EventRepository.Insert(ev);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an event: {ev.Name} {ex}");
                _unitOfWork.Rollback();
            }
        }

        [HttpDelete]
        [Route("{evId}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid evId)
        {
            try
            {
                _unitOfWork.EventRepository.Delete(evId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when deleting an event: {evId} {ex}");
                _unitOfWork.Rollback();
                //throw new Exception(ex.ToString());
            }
        }
    }
}