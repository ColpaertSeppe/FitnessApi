namespace FitnessApi.Models
{
    public class Athlete : User
    {
        public double Weight { get; set; }  
        public int Height { get; set; }
        public List<TrainingPlan> TrainingPlans { get; set;}
        public Athlete()
        {
            TrainingPlans = new List<TrainingPlan>();
        }

        public Athlete(string firstName, string lastName, string email, DateTime dateOfBirth, double weight, int height) : base(firstName, lastName, email, dateOfBirth)
        {
            this.Weight = weight;   
            this.Height = height;
            this.TrainingPlans = new();
        }

        public Athlete(int id, string firstName, string lastName, string email, DateTime dateOfBirth, double weight, int height) : base(id, firstName, lastName, email, dateOfBirth)
        {
            this.Weight = weight;
            this.Height = height;
            this.TrainingPlans = new();
        }

        
    }
}
