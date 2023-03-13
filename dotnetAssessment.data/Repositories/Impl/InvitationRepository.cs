using Microsoft.EntityFrameworkCore;
using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories.Impl
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<Invitation> GetInvitationByDeveloperName(string attendantName)
        {
            return context.Set<Invitation>().FirstOrDefaultAsync(attendant => attendant.Developer.Name == attendantName);
        }

        public Task<Invitation> GetInvitationByEventName(string eventName)
        {
            return context.Set<Invitation>().FirstOrDefaultAsync(inv => inv.Event.Name == eventName);
        }
    }
}