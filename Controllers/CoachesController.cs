using FitnessApi.Data;
using FitnessApi.DTOs;
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
        public async Task<ActionResult<IEnumerable<CoachDTO>>> GetCoaches()
        {
            return await _context.Coaches.Select(x => new CoachDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Biography = x.Biography,
            }).ToListAsync();
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CoachDTO>>> GetCoachDetail(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return await _context.Coaches.Where(x => x.Id == id).Select(x => new CoachDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Biography = x.Biography,
                Athletes = x.Athletes,
            }).ToListAsync();
        }

    }
}
