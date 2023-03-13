using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private IDeveloperRepository _developerRepository;
        private IEventRepository _eventRepository;
        private IInvitationRepository _invitationRepository;
        private IRepository<Address> _addressRepository;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public IDeveloperRepository DeveloperRepository
        {
            get { return _developerRepository = _developerRepository ?? new DeveloperRepository(_databaseContext);}
        }
        public IEventRepository EventRepository
        {
            get { return _eventRepository = _eventRepository ?? new EventRepository(_databaseContext);}
        }
        public IInvitationRepository InvitationRepository
        {
            get { return _invitationRepository = _invitationRepository ?? new InvitationRepository(_databaseContext);}
        }
        public IRepository<Address> AddressRepository
        {
            get { return _addressRepository = _addressRepository ?? new Repository<Address>(_databaseContext);}
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void Rollback()
        {
            _databaseContext.Dispose();
        }
    }
}