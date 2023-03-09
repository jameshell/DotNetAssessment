using System.Threading.Tasks;
using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> GetByName(string firstName);
    }
}