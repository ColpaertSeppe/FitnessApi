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
                var plans = CreatePlans();
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

        public static List<TrainingPlan> CreatePlans()
        {
            TrainingPlan plan1 = new TrainingPlan(1,"plan 1", "dit is plan 1");
            TrainingPlan plan2 = new TrainingPlan(2,"plan 2", "dit is plan 2");

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
