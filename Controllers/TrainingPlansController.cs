using FitnessApi.Data;
using FitnessApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlansController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainingPlansController(DataContext context)
        {
            _context = context;
        }

        // api/TrainingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlanDTO.IndexPlan>>> GetPlans()
        {
            return await _context.TrainingPlans.Select(x => new TrainingPlanDTO.IndexPlan
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                
            }).ToListAsync();
        }
    }
}
