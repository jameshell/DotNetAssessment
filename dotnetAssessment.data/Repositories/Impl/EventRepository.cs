using Microsoft.EntityFrameworkCore;
using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories.Impl
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<Event> GetEventByDeveloperName(string devName)
        {
            return context.Set<Event>().FirstOrDefaultAsync(ev => ev.Developer.Name == devName);
        }

        public Task<Event> GetEventByName(String eventName)
        {
            return context.Set<Event>().FirstOrDefaultAsync(ev => ev.Name == eventName);
        }
    }
}