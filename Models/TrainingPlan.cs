using FitnessApi.DTOs;

namespace FitnessApi.Models { 
    public class TrainingPlan : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<TrainingDay> TrainingDays { get; set; }
        public IList<Athlete> Athletes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public TrainingPlan() { }
        public TrainingPlan(TrainingPlanDTO plan)
        {
            this.Id = plan.Id;
            this.Name = plan.Name;
            this.Description = plan.Description;

            this.TrainingDays = new List<TrainingDay>();
            this.Athletes = new List<Athlete>();

            //tracking
            this.CreatedOn = plan.CreatedOn;
            this.CreatedBy = plan.CreatedBy;
            this.ModifiedOn = plan.ModifiedOn;
            this.ModifiedBy = plan.ModifiedBy;
        }
    }
}
