using FitnessApi.Data;
using FitnessApi.DTOs;
using FitnessApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AthletesController(DataContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        //GET: api/Atheletes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AthleteDTO>>> GetAtheletes()
        {
            //return await _context.Athletes.Select(x => new AthleteDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Email = x.Email,
            //    DateOfBirth = x.DateOfBirth,
            //    Height = x.Height,
            //    Weight = x.Weight,
            //}).ToListAsync();

            var athletes = new List<AthleteDTO>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "SELECT Id, FirstName, LastName, Email, DateOfBirth, Height, Weight FROM athlete";

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var athlete = new AthleteDTO()
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Height = (int)reader["Height"],
                        Weight = (double)reader["Weight"],
                    };
                    athletes.Add(athlete);
                }

                connection.Close();
            }

                return athletes;
        }

        // GET: api/Atheletes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AthleteDTO>>> GetAthleteDetail(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);

            if (athlete == null)
            {
                return NotFound();
            }

            return await _context.Athletes.Where(x => x.Id == id).Select(x => new AthleteDTO
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
