using dotnetAssessment.core.Models;
using dotnetAssessment.data.Repositories;
using Microsoft.Extensions.Logging;

namespace dotnetAssessment.business.Services.Impl
{
    public class EventService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<EventService> _logger;
        public EventService(IUnitOfWork unitOfWork, ILogger<EventService> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        
    }
}