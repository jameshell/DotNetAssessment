using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IDeveloperService
    {
        IEnumerable<Developer> GetAllDevelopers();
        Task<Developer> GetDeveloperByName(string devName);
        Task<Developer> AddDeveloper(Developer dev);
        Task<Guid> DeleteDeveloper(Guid devId);
    }
}