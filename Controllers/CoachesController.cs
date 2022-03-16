using FitnessApi.Data;
using FitnessApi.DTOs;
using FitnessApi.Models;
using FitnessApi.ViewModels.AthletesViewModels;
using FitnessApi.ViewModels.CoahesViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public CoachesController(DataContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // api/coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachIndexViewModel>>> GetCoaches()
        {
            //return await _context.Coaches.Select(x => new CoachDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Email = x.Email,
            //    DateOfBirth = x.DateOfBirth,
            //    Biography = x.Biography,
            //}).ToListAsync();
            var coaches = new List<CoachIndexViewModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "SELECT * FROM coach";

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var coach = new CoachIndexViewModel()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                    };
                    coaches.Add(coach);
                }
                connection.Close();
            }
            return coaches;
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachDetailViewModel>> GetCoachDetail(int id)
        {
            //    var coach = await _context.Coaches.FindAsync(id);

            //    if (coach == null)
            //    {
            //        return NotFound();
            //    }

            //    return await _context.Coaches.Where(x => x.Id == id).Select(x => new CoachDTO
            //    {
            //        Id = x.Id,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        Email = x.Email,
            //        DateOfBirth = x.DateOfBirth,
            //        Biography = x.Biography,
            //        Athletes = x.Athletes,
            //    }).ToListAsync();
            //}

            var coach = new CoachDetailViewModel();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "select c.Id as cId, c.FirstName as cFName, c.LastName as cFName, c.DateOfBirth as cBirth, c.Email, c.Height, c.Weight, c.Biography, " +
                    "a.Id as aId, a.FirstName as aFName, a.LastName as aLName, a.DateOfBirth as aBirth " +
                    "from Coach c " +
                    "left join athlete a on c.Id = a.CoachId " +
                    "where c.Id = " + id.ToString();

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                bool flag = true;

                while (reader.Read())
                {
                    //moet maar 1x doorlopen worden aangezien het over 1 coach gaat
                    if (flag)
                    {
                        coach = new CoachDetailViewModel()
                        {
                            Id = (int)reader["cId"],
                            FirstName = (string)reader["cFName"],
                            LastName = (string)reader["cLName"],
                            Email = (string)reader["Email"],
                            DateOfBirth = (DateTime)reader["cBirth"],
                            Height = (int)reader["Height"],
                            Weight = (double)reader["Weight"],
                            Athletes = new List<AthleteIndexViewModel>(),
                        };

                        flag = false;
                    }

                    //kijken als col 13 AthletesId uit tussentabbel AthleteTrainingPlan null is
                    if (!reader.IsDBNull(8))
                    {
                        var athlete = new AthleteIndexViewModel()
                        {
                            Id = (int)reader["aId"],
                            FirstName = (string)reader["aFName"],
                            LastName = (string)reader["aLName"],
                            DateOfBirth = (DateTime)reader["aBirth"],
                        };

                        coach.Athletes.Add(athlete);
                    }
                }
                connection.Close();
            }
            return coach;

        }
    }
}
