using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.core.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.business.Services;

namespace dotnetAssessment.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Developer> GetAllDevelopers ()=> _developerService.GetAllDevelopers();

        [HttpGet]
        [Route("{devName}")]
        public Task<Developer> GetDeveloperByName(string devName) => _developerService.GetDeveloperByName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public Task<Developer> AddDeveloper([FromBody] Developer dev) => _developerService.AddDeveloper(dev);

        [HttpDelete]
        [Route("{devId:guid}")]
        [AllowAnonymous]
        public Task<Guid> DeleteDeveloper(Guid devId) => _developerService.DeleteDeveloper(devId);

    }
}