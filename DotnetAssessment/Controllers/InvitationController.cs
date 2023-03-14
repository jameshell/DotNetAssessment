using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.Repositories;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<InvitationController> _logger;

        public InvitationController(IUnitOfWork unitOfWork, ILogger<InvitationController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Invitation> GetAllInvitations() => _unitOfWork.InvitationRepository.GetAll();

        [HttpGet]
        [Route("Events/{eventName}")]
        public Task<Invitation> GetInvitationByEventName(string eventName) => _unitOfWork.InvitationRepository.GetInvitationByEventName(eventName);

        [HttpGet]
        [Route("Guests/{devName}")]
        public Task<Invitation> GetInvitationByDeveloperName(string devName) => _unitOfWork.InvitationRepository.GetInvitationByDeveloperName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddInvitation([FromBody] Invitation inv)
        {
            try
            {
                _unitOfWork.InvitationRepository.Insert(inv);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an invitation: {inv.Id} {ex}");
                _unitOfWork.Rollback();
            }
        }

        [HttpDelete]
        [Route("{invId}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid invId)
        {
            try
            {
                _unitOfWork.InvitationRepository.Delete(invId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an invitation. {invId} {ex}");
                _unitOfWork.Rollback();
            }
        }
    }
}