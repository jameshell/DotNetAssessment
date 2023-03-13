using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        Task<Event> GetEventByName(string eventName);
        Task<Event> GetEventByDeveloperName(string devName);
        void AddEvent(Event ev);
        void DeleteEvent(Guid eventId);
    }
}