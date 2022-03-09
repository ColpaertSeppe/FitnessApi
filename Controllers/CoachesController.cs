using FitnessApi.Data;
using FitnessApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly DataContext _context;

        public CoachesController(DataContext context)
        {
            _context = context;
        }

        // api/coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachDTO.IndexCoach>>> GetCoaches()
        {
            return await _context.Coaches.Select(x => new CoachDTO.IndexCoach
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Biography = x.Biography,
            }).ToListAsync();
        }

        // todo
        // api/coaches/id

     
    }
}
