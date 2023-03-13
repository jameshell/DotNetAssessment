using dotnetAssessment.core.Models;
using dotnetAssessment.data.Repositories;
using Microsoft.Extensions.Logging;

namespace dotnetAssessment.business.Services.Impl
{
    public class EventService : IEventService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<EventService> _logger;
        public EventService(IUnitOfWork unitOfWork, ILogger<EventService> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public IEnumerable<Event> GetAllEvents() => _unitOfWork.EventRepository.GetAll();


        public Task<Event> GetEventByName(string eventName) => _unitOfWork.EventRepository.GetEventByName(eventName);

        public Task<Event> GetEventByDeveloperName(string devName) => _unitOfWork.EventRepository.GetEventByDeveloperName(devName);


        public void AddEvent(Event ev)
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

        public void DeleteEvent(Guid eventId)
        {
            try
            {
                _unitOfWork.EventRepository.Delete(eventId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when deleting an event: {eventId} {ex}");
                _unitOfWork.Rollback();
                //throw new Exception(ex.ToString());
            }
        }
    }
}