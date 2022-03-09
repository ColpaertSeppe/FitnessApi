namespace FitnessApi.Models { 
    public class AtheleteDTO
    {
        public class IndexAthlete
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public double Weight { get; set; }
            public int Height { get; set; }
        }

        public class DetailAthlete : IndexAthlete
        {
            public List<TrainingPlan> TrainingPlans { get; set; }
        }
    }
        
}
