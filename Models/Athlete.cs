using FitnessApi.DTOs;

namespace FitnessApi.Models
{
    public class Athlete : User
    {

        public IList<TrainingPlan> TrainingPlans { get; set;}
        //public Coach Coach { get; set; }

        public Athlete()
        {
            TrainingPlans = new List<TrainingPlan>();
        }

        public Athlete(AthleteDTO athlete)
        {
            this.Id = athlete.Id;
            this.FirstName = athlete.FirstName;
            this.LastName = athlete.LastName;
            this.Email = athlete.Email;
            this.DateOfBirth = athlete.DateOfBirth;

            this.Weight = athlete.Weight;
            this.Height = athlete.Height;
            

            this.TrainingPlans = new List<TrainingPlan>();

            //tracking
            this.CreatedOn = athlete.CreatedOn;
            this.CreatedBy = athlete.CreatedBy;
            this.ModifiedOn = athlete.ModifiedOn;
            this.ModifiedBy = athlete.ModifiedBy;
        }
    }
}
