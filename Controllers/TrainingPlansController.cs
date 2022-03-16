using FitnessApi.Data;
using FitnessApi.DTOs;
using FitnessApi.Models;
using FitnessApi.ViewModels.TrainingDayViewModels;
using FitnessApi.ViewModels.TrainingPlansViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlansController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public TrainingPlansController(DataContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // api/TrainingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlanIndexViewModel>>> GetPlans()
        {
            //return await _context.TrainingPlans.Select(x => new TrainingPlanDTO
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,

            //}).ToListAsync();

            var days = new List<TrainingPlanIndexViewModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "SELECT * FROM trainingplan";

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var day = new TrainingPlanIndexViewModel()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                    };
                    days.Add(day);
                }
                connection.Close();
            }
            return days;
        }

        // GET: api/TrainingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainingPlanDTO>>> GetTrainingPlanDetail(int id)
        {
            var coach = await _context.TrainingPlans.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return await _context.TrainingPlans.Where(x => x.Id == id).Select(x => new TrainingPlanDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description= x.Description,
                TrainingDays = x.TrainingDays,
            }).ToListAsync();
        }
    }
}
