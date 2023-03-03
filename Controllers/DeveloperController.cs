
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetAssessment.Models;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;
        private readonly DeveloperDbContext _context;

        public DeveloperController(ILogger<DeveloperController> logger, DeveloperDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopers()
        {
            List<Developer> devs = _context.GetDevelopers();
            return Ok(devs);
        }
    }
}