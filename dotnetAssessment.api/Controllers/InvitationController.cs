using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.core.Models;
using dotnetAssessment.business.Services;
using Microsoft.AspNetCore.Authorization;

namespace dotnetAssessment.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _invitationService;
        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Invitation> GetAllInvitations() => _invitationService.GetAllInvitations();

        [HttpGet]
        [Route("Events/{eventName}")]
        public Task<Invitation> GetInvitationByEventName(string eventName) => _invitationService.GetInvitationByEventName(eventName);

        [HttpGet]
        [Route("Guests/{devName}")]
        public Task<Invitation> GetInvitationByDeveloperName(string devName) => _invitationService.GetInvitationByDeveloperName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddInvitation([FromBody] Invitation inv) => _invitationService.AddInvitation(inv);

        [HttpDelete]
        [Route("{invId:guid}")]
        [AllowAnonymous]
        public void DeleteEvent(Guid invId) => _invitationService.DeleteInvitation(invId);
    }
}