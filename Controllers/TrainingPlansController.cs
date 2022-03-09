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

        // GET: api/TrainingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainingPlanDTO.DetailPlan>>> GetTrainingPlanDetail(int id)
        {
            var coach = await _context.TrainingPlans.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return await _context.TrainingPlans.Where(x => x.Id == id).Select(x => new TrainingPlanDTO.DetailPlan
            {
                Id = x.Id,
                Name = x.Name,
                Description= x.Description,
                TrainingDays = x.TrainingDays,
            }).ToListAsync();
        }
    }
}
