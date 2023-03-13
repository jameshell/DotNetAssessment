using dotnetAssessment.core.Models;
using dotnetAssessment.data.Repositories;
using Microsoft.Extensions.Logging;

namespace dotnetAssessment.business.Services.Impl
{
    public class DeveloperService : IDeveloperService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<DeveloperService> _logger;
        public DeveloperService(IUnitOfWork unitOfWork, ILogger<DeveloperService> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public Task<Developer> AddDeveloper(Developer dev)
        {
            try
            {
                _unitOfWork.DeveloperRepository.Insert(dev);
                _unitOfWork.Commit();
                return Task.FromResult(dev);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating a Developer: {dev.Id}");
                _unitOfWork.Rollback();
                return Task.FromResult(new Developer());
            }
        }

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

        public IEnumerable<Developer> GetAllDevelopers() => _unitOfWork.DeveloperRepository.GetAll();

        public Task<Developer> GetDeveloperByName(string devName) => _unitOfWork.DeveloperRepository.GetByName(devName);
    }
}