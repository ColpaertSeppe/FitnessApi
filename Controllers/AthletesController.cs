﻿using FitnessApi.Data;
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
            return await _context.Athletes.Select(x => new AthleteIndexViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
            }).ToListAsync();

            //var athletes = new List<AthleteIndexViewModel>();

            //using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            //{
            //    var sql = "SELECT * FROM athlete";

            //    connection.Open();
            //    using SqlCommand command = new(sql, connection);
            //    using SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var athlete = new AthleteIndexViewModel()
            //        {
            //            Id = (int)reader["Id"],
            //            FirstName = (string)reader["FirstName"],
            //            LastName = (string)reader["LastName"],
            //            DateOfBirth = (DateTime)reader["DateOfBirth"],
            //        };
            //        athletes.Add(athlete);
            //    }
            //    connection.Close();
            //}
            //return athletes;
        }

        // GET: api/Atheletes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AthleteDetailViewModel>> GetAthleteDetail(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);

            if (athlete == null)
            {
                return NotFound();
            }
            
            var res = new AthleteDetailViewModel()
            {
                Id= athlete.Id,
                FirstName = athlete.FirstName,
                LastName = athlete.LastName,
                DateOfBirth = athlete.DateOfBirth,
                Email = athlete.Email,
                Height = athlete.Height,
                Weight = athlete.Weight,
                //TrainingPlans = athlete.TrainingPlans,
            };

            return res;

            //var athlete = new AthleteDetailViewModel();

            //using (var connection = new SqlConnection(_configuration.GetConnectionString("Fitness-db")))
            //{
            //    //left join aangezien null kan zijn
            //    var sql = "select * from athlete a " +
            //        "left join AthleteTrainingPlan atp on a.Id = atp.AthletesId " +
            //        "left join trainingplan tp on atp.TrainingPlansId = tp.Id " +
            //        "where a.Id = " + id.ToString();

            //    connection.Open();
            //    using SqlCommand command = new(sql, connection);
            //    using SqlDataReader reader = command.ExecuteReader();

            //    bool flag = true;

            //    while (reader.Read())
            //    {
            //        //moet maar 1x doorlopen worden aangezien het over 1 athlete gaat
            //        if (flag)
            //        {
            //            athlete = new AthleteDetailViewModel()
            //            {
            //                Id = (int)reader["Id"],
            //                FirstName = (string)reader["FirstName"],
            //                LastName = (string)reader["LastName"],
            //                Email = (string)reader["Email"],
            //                DateOfBirth = (DateTime)reader["DateOfBirth"],
            //                Height = (int)reader["Height"],
            //                Weight = (double)reader["Weight"],
            //                TrainingPlans = new List<TrainingPlanIndexViewModel>(),
            //            };

            //            flag = false;
            //        }

            //        //kijken als col 13 AthletesId uit tussentabbel AthleteTrainingPlan null is
            //        if (!reader.IsDBNull(13))
            //        {
            //            var trainingPlan = new TrainingPlanIndexViewModel()
            //            {
            //                Id = (int)(reader["TrainingPlansId"]),
            //                Name = (string)reader["Name"],
            //                Description = (string)reader["Description"],
            //            };

            //            athlete.TrainingPlans.Add(trainingPlan);
            //        }
            //    }
            //    connection.Close();
            //}
            //return athlete;
        }
    }
}
