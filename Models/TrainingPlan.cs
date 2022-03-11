using FitnessApi.DTOs;

namespace FitnessApi.Models { 
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<TrainingDay> TrainingDays { get; set; }
        public IList<Athlete> Athletes { get; set; }

        public TrainingPlan() { }
        public TrainingPlan(TrainingPlanDTO.IndexPlan plan)
        {
            this.Id = plan.Id;
            this.Name = plan.Name;
            this.Description = plan.Description;

            this.TrainingDays = new List<TrainingDay>();
            this.Athletes = new List<Athlete>();
        }
    }
}
