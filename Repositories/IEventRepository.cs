using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    interface IEventRepository : IRepository<Event>
    {
        Task<bool> FindByDeveloper();
        Task<bool> FindByAddress();
    }
}