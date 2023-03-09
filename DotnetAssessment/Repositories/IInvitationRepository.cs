using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Invitation> GetInvitationByEventName(string eventName);
        Task<Invitation> GetInvitationByDeveloperName(string attendant);
    } 
}