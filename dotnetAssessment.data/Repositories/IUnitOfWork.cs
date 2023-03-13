using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories
{
    public interface IUnitOfWork
    {
        IDeveloperRepository DeveloperRepository { get; }
        IEventRepository EventRepository { get; }
        IInvitationRepository InvitationRepository { get; }
        IRepository<Address> AddressRepository { get; }
        void Commit();
        void Rollback();
    }
}