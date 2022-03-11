using FitnessApi.Models;

namespace FitnessApi.DTOs
{ 
    public class CoachDTO
    {
        public class IndexCoach
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int Height { get; set; }
            public double Weight { get; set; }
            public string Biography { get; set; }
        }

        public class DetailCoach : IndexCoach
        {
            public IEnumerable<Athlete> Athletes { get; set; }
        }        
    }
}
