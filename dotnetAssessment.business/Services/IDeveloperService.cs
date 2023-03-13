using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IDeveloperService
    {
        IEnumerable<Developer> GetAllDevelopers();
        Task<Developer> GetDeveloperByName();
        Task<Developer> AddDeveloper();
        Task<Guid> DeleteDeveloper();
    }
}