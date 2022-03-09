namespace FitnessApi.Models { 
    public class TrainingDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }

        public TrainingDay(string name, string description, DateTime trainingDate)
        {
            Name = name;        
            Description = description;
            TrainingDate = trainingDate;
        }

    }
}
