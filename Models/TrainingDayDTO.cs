namespace FitnessApi.Models { 
    public class TrainingDayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
    }
}
