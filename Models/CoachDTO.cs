namespace FitnessApi.Models { 
    public class CoachDTO
    {
        public class IndexCoach
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Biography { get; set; }
        }

        public class DetailCoach : IndexCoach
        {
            public List<Athlete> Athletes { get; set; }
        }
        
    }
}
