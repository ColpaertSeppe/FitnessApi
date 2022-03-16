using FitnessApi.Data;
using FitnessApi.DTOs;
using FitnessApi.ViewModels.AthletesViewModels;
using FitnessApi.ViewModels.TrainingPlansViewModels;
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
        public async Task<ActionResult<IEnumerable<AthleteIndexViewModel>>> GetAtheletes()
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

            var athletes = new List<AthleteIndexViewModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "SELECT * FROM athlete";

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var athlete = new AthleteIndexViewModel()
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                    };
                    athletes.Add(athlete);
                }
                connection.Close();
            }
                return athletes;
        }

        // GET: api/Atheletes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AthleteDetailViewModel>>> GetAthleteDetail(int id)
        {
            //var athlete = await _context.Athletes.FindAsync(id);

            //if (athlete == null)
            //{
            //    return NotFound();
            //}

            //return await _context.Athletes.Where(x => x.Id == id).Select(x => new AthleteDetailViewModel
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Email = x.Email,
            //    DateOfBirth = x.DateOfBirth,
            //    Height = x.Height,
            //    Weight = x.Weight,
            //    TrainingPlans = x.TrainingPlans
            //}).ToListAsync();

            var athletes = new List<AthleteDetailViewModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "select * from athlete a " +
                    "join AthleteTrainingPlan atp on a.Id = atp.AthletesId " +
                    "join trainingplan tp on atp.TrainingPlansId = tp.Id " +
                    "where a.Id = " + id.ToString();

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var athlete = new AthleteDetailViewModel()
                    {
                        Id = (int)reader["AthletesId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Height = (int)reader["Height"],
                        Weight = (double)reader["Weight"],
                        TrainingPlans = new List<TrainingPlanIndexViewModel>(),
                    };

                    var trainingPlan = new TrainingPlanIndexViewModel()
                    {
                        Id = (int)(reader["TrainingPlansId"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),

                    };

                    athlete.TrainingPlans.Add(trainingPlan);

                    athletes.Add(athlete);
                }

                connection.Close();
            }

            return athletes;

        }
    }
}
