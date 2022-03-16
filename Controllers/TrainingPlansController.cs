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
        public async Task<ActionResult<TrainingPlanDetailViewModel>> GetTrainingPlanDetail(int id)
        {
            var day = new TrainingPlanDetailViewModel();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            {
                var sql = "select p.Id as pId, p.Name as pName, p.[Description] as pDescr, d.Id as dId, d.Name as dName, d.[Description] as dDescr, d.TrainingDate " +
                    "from trainingplan p " +
                    "join trainingday d on p.Id = d.TrainingPlanId " +
                    "where p.Id = " + id.ToString();

                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                bool flag = true;

                while (reader.Read())
                {
                    //moet maar 1x doorlopen worden aangezien het over 1 day gaat
                    if (flag)
                    {
                        day = new TrainingPlanDetailViewModel()
                        {
                            Id = (int)reader["pId"],
                            Name = (string)reader["pName"],
                            Description = (string)reader["pDescr"],
                            TrainingDays = new List<TrainingDayIndexViewModel>(),
                        };

                        flag = false;
                    }

                    var trainingDay = new TrainingDayIndexViewModel()
                    {
                        Id = (int)(reader["dId"]),
                        Name = (string)reader["dName"],
                        Description = (string)reader["dDescr"],
                        TrainingDate = (DateTime)reader["TrainingDate"]
                    };

                    day.TrainingDays.Add(trainingDay);

                }
                connection.Close();
            }
            return day;

        }
    }
}
