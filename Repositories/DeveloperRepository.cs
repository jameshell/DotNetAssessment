using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(DatabaseContext context) : base(context) 
        {
        }
        public Task<Developer> GetByName(string firstName)
        {
            return context.Set<Developer>().FirstOrDefaultAsync(dev => dev.Name == firstName);
        }
    }
}