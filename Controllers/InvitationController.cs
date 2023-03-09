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
        private IInvitationRepository _invRepository;

        public InvitationController(IInvitationRepository invRepository)
        {
            this._invRepository = invRepository;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Invitation> GetAllInvitations() => _invRepository.GetAll();

        [HttpGet]
        [Route("Events/{eventName}")]
        public Task<Invitation> GetInvitationByEventName(string eventName) => _invRepository.GetInvitationByEventName(eventName);

        [HttpGet]
        [Route("Guests/{devName}")]
         public Task<Invitation> GetInvitationByDeveloperName(string devName) => _invRepository.GetInvitationByDeveloperName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddInvitation([FromBody] Invitation inv) => _invRepository.Insert(inv);

        [HttpDelete]
        [Route("{invId}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid invId) => _invRepository.Delete(invId);
    }
}