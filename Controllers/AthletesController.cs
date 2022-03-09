using FitnessApi.Data;
using FitnessApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly DataContext _context;

        public AthletesController(DataContext context)
        {
            _context = context;
        }

        //GET: api/Atheletes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtheleteDTO.IndexAthlete>>> GetAtheletes()
        {
            return await _context.Athletes.Select(x => new AtheleteDTO.IndexAthlete
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Height = x.Height,
                Weight = x.Weight,
            }).ToListAsync();
        }

        // GET: api/Atheletes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AtheleteDTO.DetailAthlete>>> GetAthleteDetail(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);

            if (athlete == null)
            {
                return NotFound();
            }

            return await _context.Athletes.Where(x => x.Id == id).Select(x => new AtheleteDTO.DetailAthlete
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Height = x.Height,
                Weight = x.Weight,
                TrainingPlans = x.TrainingPlans
            }).ToListAsync();
        }
    }
}
