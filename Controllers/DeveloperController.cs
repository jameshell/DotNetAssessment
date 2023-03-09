
using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetAssessment.Repositories;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(IUnitOfWork unitOfWork, ILogger<DeveloperController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Developer> GetAllDevelopers() => _unitOfWork.DeveloperRepository.GetAll();

        [HttpGet]
        [Route("{devName}")]
        public Task<Developer> GetDeveloperByName(string devName) => _unitOfWork.DeveloperRepository.GetByName(devName);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public Task<Developer> AddDeveloper([FromBody] Developer dev)
        {
            try
            {
                _unitOfWork.DeveloperRepository.Insert(dev);
                _unitOfWork.Commit();
                return Task.FromResult(dev);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating a Developer.");
                _unitOfWork.Rollback();
                return Task.FromResult(new Developer());
            }
        } 

        [HttpDelete]
        [Route("{devId}")]
        [AllowAnonymous]
        public Task<Guid> DeleteDeveloper(Guid devId)
        {   
            try
            {
                _unitOfWork.DeveloperRepository.Delete(devId);
                _unitOfWork.Commit();
                return Task.FromResult(devId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when deleting a Developer.");
                _unitOfWork.Rollback();
                return Task.FromResult(new Guid());
            }
        }
    }
}