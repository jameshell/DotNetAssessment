using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IInvitationService
    {
        IEnumerable<Invitation> GetAllInvitations();
        Task<Invitation> GetInvitationByEventName(string eventName);
        Task<Invitation> GetInvitationByDeveloperName(string devName);
        void AddInvitation(Invitation invitation);
        void DeleteInvitation(Guid invitationId);
    }
}