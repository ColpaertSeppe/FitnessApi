using FitnessApi.DTOs;
using FitnessApi.Models;

namespace FitnessApi.Data
{
    public class DataInitializer
    {
        private readonly DataContext _dbContext;

        public DataInitializer(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public void InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                var days = CreateDays();
                _dbContext.TrainingDays.AddRange(days);
     

                var plans = CreatePlans(days);
                _dbContext.TrainingPlans.AddRange(plans);
       

                var athletes = CreateAthletes(plans);
                _dbContext.Athletes.AddRange(athletes);
       

                var coaches = CreateCoaches(athletes);
                _dbContext.Coaches.AddRange(coaches);

                _dbContext.SaveChanges();
            }
        }

        public static List<TrainingDay> CreateDays()
        {
            TrainingDayDTO dto1 = new()
            {
                //Id = -1,
                Name = "Day 1",
                Description = "Dit is dag 1",
                TrainingDate = new DateTime(2022, 1, 1)
            };
            TrainingDayDTO dto2 = new()
            {
                //Id = -2,
                Name = "Day 2",
                Description = "Dit is dag 2",
                TrainingDate = new DateTime(2022, 1, 3)
            };
            TrainingDayDTO dto3 = new()
            {
                //Id = -3,
                Name = "Day 3",
                Description = "Dit is dag 3",
                TrainingDate = new DateTime(2022, 1, 5)
            };
            TrainingDayDTO dto4 = new()
            {
                //Id = -4,
                Name = "Day 5",
                Description = "Dit is dag 6",
                TrainingDate = new DateTime(2022, 1, 8)
            };
            TrainingDayDTO dto5 = new()
            {
                //Id = -5,
                Name = "Day 5",
                Description = "Dit is dag 5",
                TrainingDate = new DateTime(2022, 1, 10)
            };
            TrainingDayDTO dto6 = new()
            {
                //Id = -6,
                Name = "Day 6",
                Description = "Dit is dag 6",
                TrainingDate = new DateTime(2022, 1, 12)
            };
            TrainingDayDTO dto7 = new()
            {
                //Id = -7,
                Name = "Training Day 7",
                Description = "Dit is training 7",
                TrainingDate = new DateTime(2022, 2, 1)
            };
            TrainingDayDTO dto8 = new()
            {
                //Id = -8,
                Name = "Training Day 8",
                Description = "Dit is training 8",
                TrainingDate = new DateTime(2022, 2, 4)
            };
            TrainingDayDTO dto9 = new()
            {
                //Id = -9,
                Name = "Training Day 9",
                Description = "Dit is training 9",
                TrainingDate = new DateTime(2022, 2, 8)
            };
            TrainingDayDTO dto10 = new()
            {
                //Id = -10,
                Name = "Training Day 10",
                Description = "Dit is training 10",
                TrainingDate = new DateTime(2022, 2, 11)
            };


            TrainingDay day1 = new(dto1);
            TrainingDay day2 = new(dto2);
            TrainingDay day3 = new(dto3);
            TrainingDay day4 = new(dto4);
            TrainingDay day5 = new(dto5);
            TrainingDay day6 = new(dto6);
            TrainingDay day7 = new(dto7);
            TrainingDay day8 = new(dto8);
            TrainingDay day9 = new(dto9);
            TrainingDay day10 = new(dto10);

            return new List<TrainingDay> { day1, day2, day3, day4, day5, day6, day7, day8, day9, day10 };
        }

        public static List<TrainingPlan> CreatePlans(List<TrainingDay> days)
        {
            TrainingPlanDTO.IndexPlan dto1 = new()
            {
                //Id = -1,
                Name = "Plan 1",
                Description = "Dit is plan 1"
            };
            TrainingPlanDTO.IndexPlan dto2 = new()
            {
                //Id = -2,
                Name = "Plan 2",
                Description = "Dit is plan 2"
            };

            TrainingPlan plan1 = new(dto1);
            TrainingPlan plan2 = new(dto2);

            plan1.TrainingDays.Add(days[0]);
            plan1.TrainingDays.Add(days[1]);
            plan1.TrainingDays.Add(days[2]);
            plan1.TrainingDays.Add(days[3]);
            plan1.TrainingDays.Add(days[4]);
            plan1.TrainingDays.Add(days[5]);

            plan2.TrainingDays.Add(days[6]);
            plan2.TrainingDays.Add(days[7]);
            plan2.TrainingDays.Add(days[8]);
            plan2.TrainingDays.Add(days[9]);

            return new List<TrainingPlan> { plan1, plan2 };
        }

        public static List<Athlete> CreateAthletes(List<TrainingPlan> plans)
        {
            AthleteDTO dto1 = new()
            {
                //Id = -1,
                FirstName = "Seppe",
                LastName = "Colpaert",
                Email = "seppe.colpaert2@gmail.com",
                DateOfBirth = new DateTime(2000, 5, 10),
                Weight = 83.5,
                Height = 191,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
            };
            AthleteDTO dto2 = new()
            {
                //Id = -2,
                FirstName = "Jan",
                LastName = "Jansens",
                Email = "jan@gmail.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Weight = 95,
                Height = 210,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
            };
            AthleteDTO dto3 = new()
            {
                //Id = -3,
                FirstName = "Peter",
                LastName = "Selie",
                Email = "peterselie@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 31),
                Weight = 70,
                Height = 170,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
            };


            Athlete athlete1 = new(dto1);
            Athlete athlete2 = new(dto2);
            Athlete athlete3 = new(dto3);

            athlete1.TrainingPlans.Add(plans[0]);
            athlete2.TrainingPlans.Add(plans[1]);

            //TODO plans bij athlete1 & 2 worden verwijderd als ze ook aan athlete 3 worden toegevoegd
            //athlete3.TrainingPlans.Add(plans[0]);
            //athlete3.TrainingPlans.Add(plans[1]);

            return new List<Athlete> { athlete1, athlete2, athlete3 };
        }

        public static List<Coach> CreateCoaches(List<Athlete> athletes)
        {
            CoachDTO dto1 = new()
            {
                //Id = -4,
                FirstName = "Bo",
                LastName = "Lava",
                Email = "lavabo@gmail.com",
                DateOfBirth = new DateTime(1980, 1, 1),
                Weight = 70,
                Height = 170,
                Biography = "Ik ben Bo",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
            };
            CoachDTO dto2 = new()
            {
                //Id = -5,
                FirstName = "Ka",
                LastName = "Ching",
                Email = "kaching@gmail.com",
                DateOfBirth = new DateTime(1980, 1, 1),
                Weight = 70,
                Height = 170,
                Biography = "Ik ben Ka",
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
            };

            Coach coach1 = new(dto1);
            Coach coach2 = new(dto2);

            coach1.Athletes.Add(athletes[0]);
            coach2.Athletes.Add(athletes[1]);
            coach2.Athletes.Add(athletes[2]);

            return new List<Coach> { coach1, coach2 };
        }
    }
}
