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
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                var days = CreateDays();
                _dbContext.TrainingDays.AddRange(days);

                var plans = CreatePlans(days);
                _dbContext.TrainingPlans.AddRange(plans);
                //_dbContext.SaveChanges();

                var athletes = CreateAthletes(plans);
                _dbContext.Athletes.AddRange(athletes);
                //_dbContext.SaveChanges();

                var coaches = CreateCoaches(athletes);
                _dbContext.Coaches.AddRange(coaches);
                _dbContext.SaveChanges();
            }

            
        }

        public static List<TrainingDay> CreateDays()
        {
            TrainingDay day1 = new TrainingDay(1,"Day 1", "Dit is dag 1", new DateTime(2022,1,1));
            TrainingDay day2 = new TrainingDay(2,"Day 2", "Dit is dag 2", new DateTime(2022,1,3));
            TrainingDay day3 = new TrainingDay(3,"Day 3", "Dit is dag 3", new DateTime(2022,1,5));
            TrainingDay day4 = new TrainingDay(4,"Day 4", "Dit is dag 4", new DateTime(2022,1,8));
            TrainingDay day5 = new TrainingDay(5,"Day 5", "Dit is dag 5", new DateTime(2022,1,10));
            TrainingDay day6 = new TrainingDay(6,"Day 6", "Dit is dag 6", new DateTime(2022,1,12));

            TrainingDay day7 = new TrainingDay(7, "training 7", "Dit is training 1", new DateTime(2022, 2, 1));
            TrainingDay day8 = new TrainingDay(8, "training 8", "Dit is training 1", new DateTime(2022, 2, 2));
            TrainingDay day9 = new TrainingDay(9, "training 9", "Dit is training 1", new DateTime(2022, 2, 3));
            TrainingDay day10 = new TrainingDay(10, "training 10", "Dit is training 1", new DateTime(2022, 2, 4));

            return new List<TrainingDay> { day1, day2, day3, day4, day5, day6, day7, day8, day9, day10 };
        }

        public static List<TrainingPlan> CreatePlans(List<TrainingDay> days)
        {
            TrainingPlan plan1 = new TrainingPlan(1,"plan 1", "dit is plan 1");
            TrainingPlan plan2 = new TrainingPlan(2,"plan 2", "dit is plan 2");

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
            Athlete athlete1 = new Athlete(1, "Seppe", "Colpaert", "seppe.colpaert2@gmail.com", new DateTime(2000, 5, 10), 83.5, 191);
            Athlete athlete2 = new Athlete(2, "Jan", "Jansens", "jan@gmail.com", new DateTime(1990, 1, 1), 95, 210);
            Athlete athlete3 = new Athlete(3, "Peter", "Selie", "peterselie@gmail.com", new DateTime(1999, 12, 31), 70, 170);

            athlete1.TrainingPlans.Add(plans[0]);
            athlete2.TrainingPlans.Add(plans[1]);

            //TODO plans bij athlete1 & 2 worden verwijderd als ze ook aan athlete 3 worden toegevoegd
            //athlete3.TrainingPlans.Add(plans[0]);
            //athlete3.TrainingPlans.Add(plans[1]);

            return new List<Athlete> { athlete1 , athlete2 , athlete3 };   
        }

        public static List<Coach> CreateCoaches(List<Athlete> athletes)
        {
            Coach coach1 = new Coach(4, "Bo", "Lava", "lavabo@gmail.com", new DateTime(1980, 1, 1), "Ik ben Bo en ik sport graag");
            Coach coach2 = new Coach(5, "Ka", "Ching", "kaching@gmail.com", new DateTime(1980, 1, 1), "Ik ben Ka en ik sport zeer graag");

            coach1.Athletes.Add(athletes[0]);
            coach2.Athletes.Add(athletes[1]);
            coach2.Athletes.Add(athletes[2]);

            return new List<Coach> { coach1, coach2};
        }
    }
}
