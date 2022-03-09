namespace FitnessApi.Models { 
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrainingDay> TrainingDays { get; set; }

        public TrainingPlan(string name, string description)
        {
            Name = name;
            Description = description;
            TrainingDays = new List<TrainingDay>();
        }

        public TrainingPlan(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            TrainingDays = new List<TrainingDay>();
        }

    }
}
