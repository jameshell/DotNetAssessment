
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.Repositories;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private IDeveloperRepository _devRepository;

        public DeveloperController(IDeveloperRepository devRepository)
        {
            this._devRepository = devRepository;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Developer> GetAllDevelopers() => _devRepository.GetAll();

        [HttpGet]
        [Route("{devName}")]
         public Task<Developer> GetDeveloperByName(string devName) => _devRepository.GetByName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddDeveloper([FromBody] Developer dev) => _devRepository.Insert(dev);

        [HttpDelete]
        [Route("{devId}")]
        [AllowAnonymous]
        public void DeleteDeveloper(Guid devId) => _devRepository.Delete(devId);
    }
}