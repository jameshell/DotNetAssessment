using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Invitation> GetInvitationByEventName(string eventName);
        Task<Invitation> GetInvitationByDeveloperName(string attendant);
    } 
}