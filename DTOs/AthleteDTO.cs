using FitnessApi.Models;

namespace FitnessApi.DTOs
{ 
    public class AthleteDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }

        public IList<TrainingPlan> TrainingPlans { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }


        //public class IndexAthlete
        //{
        //    public int Id { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string Email { get; set; }
        //    public DateTime DateOfBirth { get; set; }
        //    public double Weight { get; set; }
        //    public int Height { get; set; }
        //}

        //public class DetailAthlete : IndexAthlete
        //{
        //    public IEnumerable<TrainingPlan> TrainingPlans { get; set; }
        //}

        //public class CreateAthlete : IndexAthlete
        //{
        //    public string CreatedBy { get; set; }  
        //}
    }

}
