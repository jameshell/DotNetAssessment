using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetEventByName(string eventName);
        Task<Event> GetEventByDeveloperName(string devName);
    }
}