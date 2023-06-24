using dotnetAssessment.core.Models;
using dotnetAssessment.data.Repositories;
using Microsoft.Extensions.Logging;

namespace dotnetAssessment.business.Services.Impl
{
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<InvitationService> _logger;

        public InvitationService(IUnitOfWork unitOfWork, ILogger<InvitationService> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public IEnumerable<Invitation> GetAllInvitations() => _unitOfWork.InvitationRepository.GetAll();

        public Task<Invitation> GetInvitationByEventName(string eventName) => _unitOfWork.InvitationRepository.GetInvitationByEventName(eventName);

        public Task<Invitation> GetInvitationByDeveloperName(string devName) => _unitOfWork.InvitationRepository.GetInvitationByDeveloperName(devName);

        public void AddInvitation(Invitation invitation)
        {
            try
            {
                _unitOfWork.InvitationRepository.Insert(invitation);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an invitation: {invitation.Id} {ex}");
                _unitOfWork.Rollback();
            }
        }

        public void DeleteInvitation(Guid invitationId)
        {
            try
            {
                _unitOfWork.InvitationRepository.Delete(invitationId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when deleting an invitation. {invitationId} {ex}");
                _unitOfWork.Rollback();
            }
        }
    }
}