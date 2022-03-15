using FitnessApi.Models;

namespace FitnessApi.DTOs
{
    public class TrainingPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TrainingDay> TrainingDays { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        //public class IndexPlan
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Description { get; set; }
        //}

        //public class DetailPlan : IndexPlan
        //{
        //    public IEnumerable<TrainingDay> TrainingDays { get; set; }
        //}
    }
}
