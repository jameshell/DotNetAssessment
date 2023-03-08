using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetEventByName(string eventName);
        Task<Event> GetEventByDeveloperName(string devName);
    }
}