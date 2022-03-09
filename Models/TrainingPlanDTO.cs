namespace FitnessApi.Models
{
    public class TrainingPlanDTO
    {
        public class IndexPlan
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class DetailPlan : IndexPlan
        {
            public List<TrainingDay> TrainingDays { get; set; }
        }
        
        
    }
}
