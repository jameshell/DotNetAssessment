using System.Threading.Tasks;
using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> GetByName(string firstName);
    }
}